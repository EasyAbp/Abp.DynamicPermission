using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using EasyAbp.Abp.DynamicPermission.Localization;
using EasyAbp.Abp.DynamicPermission.PermissionDefinitions;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Volo.Abp;
using Volo.Abp.Authorization.Permissions;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Localization;
using Volo.Abp.Threading;
using PermissionDefinition = Volo.Abp.Authorization.Permissions.PermissionDefinition;

namespace EasyAbp.Abp.DynamicPermission.Authorization
{
    [Dependency(ReplaceServices = true)]
    public class DynamicIncludedPermissionDefinitionManager : IPermissionDefinitionManager, ISingletonDependency
    {
        protected IDictionary<string, PermissionGroupDefinition> StaticPermissionGroupDefinitions => _lazyStaticPermissionGroupDefinitions.Value;
        private readonly Lazy<Dictionary<string, PermissionGroupDefinition>> _lazyStaticPermissionGroupDefinitions;

        protected IDictionary<string, PermissionDefinition> StaticPermissionDefinitions => _lazyStaticPermissionDefinitions.Value;
        private readonly Lazy<Dictionary<string, PermissionDefinition>> _lazyStaticPermissionDefinitions;

        protected AbpPermissionOptions Options { get; }

        private readonly IDynamicPermissionDefinitionStore _dynamicPermissionDefinitionStore;
        private readonly IServiceProvider _serviceProvider;
        
        public DynamicIncludedPermissionDefinitionManager(
            IDynamicPermissionDefinitionStore dynamicPermissionDefinitionStore,
            IOptions<AbpPermissionOptions> options,
            IServiceProvider serviceProvider)
        {
            _dynamicPermissionDefinitionStore = dynamicPermissionDefinitionStore;
            _serviceProvider = serviceProvider;
            Options = options.Value;

            _lazyStaticPermissionDefinitions = new Lazy<Dictionary<string, PermissionDefinition>>(
                CreateStaticPermissionDefinitions,
                isThreadSafe: true
            );

            _lazyStaticPermissionGroupDefinitions = new Lazy<Dictionary<string, PermissionGroupDefinition>>(
                CreatePermissionGroupDefinitions,
                isThreadSafe: true
            );
        }


        public virtual PermissionDefinition Get(string name)
        {
            var permission = GetOrNull(name);

            if (permission == null)
            {
                throw new AbpException("Undefined permission: " + name);
            }

            return permission;
        }

        public virtual PermissionDefinition GetOrNull(string name)
        {
            Check.NotNull(name, nameof(name));

            var permissionDefinition = GetStaticOrNull(name) ?? GetDynamicOrNull(name);

            return permissionDefinition;
        }
        
        protected virtual PermissionDefinition GetStaticOrNull(string name)
        {
            return StaticPermissionDefinitions.GetOrDefault(name);
        }
        
        protected virtual PermissionDefinition GetDynamicOrNull(string name)
        {
            var dynamicPermissionDefinition =
                AsyncHelper.RunSync(async () => await _dynamicPermissionDefinitionStore.GetAsync(name));

            return new DynamicPermissionDefinition(dynamicPermissionDefinition.Name,
                L(dynamicPermissionDefinition.DisplayName));
        }

        public virtual IReadOnlyList<PermissionDefinition> GetPermissions()
        {
            return GetStaticPermissions().Concat(GetDynamicPermissions()).ToList();
        }
        
        protected virtual IReadOnlyList<PermissionDefinition> GetStaticPermissions()
        {
            return StaticPermissionDefinitions.Values.ToImmutableList();
        }
        
        protected virtual IReadOnlyList<PermissionDefinition> GetDynamicPermissions()
        {
            return GetDynamicGroup().Permissions;
        }

        public virtual IReadOnlyList<PermissionGroupDefinition> GetGroups()
        {
            return GetStaticGroups().Concat(new List<PermissionGroupDefinition> {GetDynamicGroup()}).ToList();
        }

        protected virtual IReadOnlyList<PermissionGroupDefinition> GetStaticGroups()
        {
            return StaticPermissionGroupDefinitions.Values.ToImmutableList();
        }

        protected virtual PermissionGroupDefinition GetDynamicGroup()
        {
            var group = new DynamicPermissionGroupDefinition("DynamicPermission", L("DynamicPermission"));

            var dynamicPermissionDefinitions =
                AsyncHelper.RunSync(async () => await _dynamicPermissionDefinitionStore.GetDictionaryAsync()).Values;
            
            foreach (var dynamicPermissionDefinition in dynamicPermissionDefinitions)
            {
                group.AddPermission(dynamicPermissionDefinition.Name, L(dynamicPermissionDefinition.DisplayName));
            }

            return group;
        }

        private static LocalizableString L(string name)
        {
            return LocalizableString.Create<DynamicPermissionResource>(name);
        }

        protected virtual Dictionary<string, PermissionDefinition> CreateStaticPermissionDefinitions()
        {
            var permissions = new Dictionary<string, PermissionDefinition>();

            foreach (var groupDefinition in StaticPermissionGroupDefinitions.Values)
            {
                foreach (var permission in groupDefinition.Permissions)
                {
                    AddPermissionToDictionaryRecursively(permissions, permission);
                }
            }

            return permissions;
        }

        protected virtual void AddPermissionToDictionaryRecursively(
            Dictionary<string, PermissionDefinition> permissions,
            PermissionDefinition permission)
        {
            if (permissions.ContainsKey(permission.Name))
            {
                throw new AbpException("Duplicate permission name: " + permission.Name);
            }

            permissions[permission.Name] = permission;

            foreach (var child in permission.Children)
            {
                AddPermissionToDictionaryRecursively(permissions, child);
            }
        }

        protected virtual Dictionary<string, PermissionGroupDefinition> CreatePermissionGroupDefinitions()
        {
            using (var scope = _serviceProvider.CreateScope())
            {
                var context = new PermissionDefinitionContext(scope.ServiceProvider);

                var providers = Options
                        .DefinitionProviders
                        .Select(p => scope.ServiceProvider.GetRequiredService(p) as IPermissionDefinitionProvider)
                        .ToList();

                foreach (var provider in providers)
                {
                    provider.PreDefine(context);
                }

                foreach (var provider in providers)
                {
                    provider.Define(context);
                }

                foreach (var provider in providers)
                {
                    provider.PostDefine(context);
                }

                return context.Groups;
            }
        }
    }
}