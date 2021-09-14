using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using EasyAbp.Abp.DynamicPermission.PermissionDefinitions;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Security.Claims;

namespace EasyAbp.Abp.DynamicPermission.Authorization
{
    public class DynamicPermissionChecker : IDynamicPermissionChecker, ITransientDependency
    {
        protected ICurrentPrincipalAccessor PrincipalAccessor { get; }
        protected IDynamicPermissionDefinitionStore DynamicPermissionDefinitionStore { get; }
        protected IEnumerable<IDynamicPermissionValueProvider> DynamicPermissionValueProviders { get; }

        public DynamicPermissionChecker(
            ICurrentPrincipalAccessor principalAccessor,
            IDynamicPermissionDefinitionStore dynamicPermissionDefinitionStore,
            IEnumerable<IDynamicPermissionValueProvider> dynamicPermissionValueProviders)
        {
            PrincipalAccessor = principalAccessor;
            DynamicPermissionDefinitionStore = dynamicPermissionDefinitionStore;
            DynamicPermissionValueProviders = dynamicPermissionValueProviders;
        }
        
        public virtual async Task<bool> IsGrantedAsync(string name)
        {
            return await IsGrantedAsync(PrincipalAccessor.Principal, name);
        }

        public virtual async Task<bool> IsGrantedAsync(ClaimsPrincipal claimsPrincipal, string name)
        {
            var permissionDefinition = await DynamicPermissionDefinitionStore.GetAsync(name);
            
            var isGranted = false;
            var context = new DynamicPermissionValueCheckContext(permissionDefinition, claimsPrincipal);
            foreach (var provider in DynamicPermissionValueProviders)
            {
                var result = await provider.CheckAsync(context);

                if (result == DynamicPermissionGrantResult.Granted)
                {
                    isGranted = true;
                }
                else if (result == DynamicPermissionGrantResult.Prohibited)
                {
                    return false;
                }
            }

            return isGranted;
        }
    }
}