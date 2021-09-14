using JetBrains.Annotations;
using Microsoft.AspNetCore.Authorization.Infrastructure;

namespace EasyAbp.Abp.DynamicPermission.Authorization
{
    public class DynamicPermissionAuthorizationRequirement : OperationAuthorizationRequirement
    {
        public DynamicPermissionAuthorizationRequirement([NotNull] string name)
        {
            Name = name;
        }
    }
}