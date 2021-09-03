using EasyAbp.Abp.DynamicPermission.Localization;
using Volo.Abp.AspNetCore.Mvc;

namespace EasyAbp.Abp.DynamicPermission
{
    public abstract class DynamicPermissionController : AbpController
    {
        protected DynamicPermissionController()
        {
            LocalizationResource = typeof(DynamicPermissionResource);
        }
    }
}
