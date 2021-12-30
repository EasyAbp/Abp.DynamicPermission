using EasyAbp.Abp.DynamicPermission.Localization;
using Microsoft.AspNetCore.Mvc;
using Volo.Abp.AspNetCore.Mvc;

namespace EasyAbp.Abp.DynamicPermission
{
    [Area(AbpDynamicPermissionRemoteServiceConsts.ModuleName)]
    public abstract class DynamicPermissionController : AbpControllerBase
    {
        protected DynamicPermissionController()
        {
            LocalizationResource = typeof(DynamicPermissionResource);
        }
    }
}
