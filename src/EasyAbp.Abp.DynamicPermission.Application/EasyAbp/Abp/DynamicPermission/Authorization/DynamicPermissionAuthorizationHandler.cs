using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Volo.Abp.DependencyInjection;

namespace EasyAbp.Abp.DynamicPermission.Authorization
{
    public class DynamicPermissionAuthorizationHandler : AuthorizationHandler<DynamicPermissionAuthorizationRequirement>, ITransientDependency
    {
        protected IDynamicPermissionChecker DynamicPermissionChecker { get; }

        public DynamicPermissionAuthorizationHandler(IDynamicPermissionChecker dynamicPermissionChecker)
        {
            DynamicPermissionChecker = dynamicPermissionChecker;
        }
        
        protected override async Task HandleRequirementAsync(AuthorizationHandlerContext context, DynamicPermissionAuthorizationRequirement requirement)
        {
            if (await DynamicPermissionChecker.IsGrantedAsync(requirement.Name))
            {
                context.Succeed(requirement);
                return;
            }
            
            context.Fail();
        }
    }
}