using EasyAbp.Abp.DynamicPermission.Localization;
using Volo.Abp.Application.Services;

namespace EasyAbp.Abp.DynamicPermission
{
    public abstract class DynamicPermissionAppService : ApplicationService
    {
        protected DynamicPermissionAppService()
        {
            LocalizationResource = typeof(DynamicPermissionResource);
            ObjectMapperContext = typeof(AbpDynamicPermissionApplicationModule);
        }
    }
}
