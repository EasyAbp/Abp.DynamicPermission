using System.Threading.Tasks;
using EasyAbp.Abp.DynamicPermission.PermissionGrants;
using Volo.Abp.Security.Claims;

namespace EasyAbp.Abp.DynamicPermission.Authorization
{
    public class UserDynamicPermissionValueProvider : DynamicPermissionValueProvider
    {
        public const string ProviderName = "U";

        public override string Name => ProviderName;

        public UserDynamicPermissionValueProvider(IDynamicPermissionStore dynamicPermissionStore) : base(
            dynamicPermissionStore)
        {
        }
        
        public override async Task<DynamicPermissionGrantResult> CheckAsync(DynamicPermissionValueCheckContext context)
        {
            var userId = context.Principal?.FindFirst(AbpClaimTypes.UserId)?.Value;

            if (userId == null)
            {
                return DynamicPermissionGrantResult.Undefined;
            }

            return await DynamicPermissionStore.IsGrantedAsync(context.Permission.Name, Name, userId)
                ? DynamicPermissionGrantResult.Granted
                : DynamicPermissionGrantResult.Undefined;
        }
    }
}