using System.Security.Claims;
using EasyAbp.Abp.DynamicPermission.PermissionDefinitions;
using JetBrains.Annotations;
using Volo.Abp;

namespace EasyAbp.Abp.DynamicPermission.Authorization
{
    public class DynamicPermissionValueCheckContext
    {
        [NotNull]
        public PermissionDefinition Permission { get; }

        [CanBeNull]
        public ClaimsPrincipal Principal { get; }

        public DynamicPermissionValueCheckContext(
            [NotNull] PermissionDefinition permission, 
            [CanBeNull] ClaimsPrincipal principal)
        {
            Check.NotNull(permission, nameof(permission));

            Permission = permission;
            Principal = principal;
        }
    }
}