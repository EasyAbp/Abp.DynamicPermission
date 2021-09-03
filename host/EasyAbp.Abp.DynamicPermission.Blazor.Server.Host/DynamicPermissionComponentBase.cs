using EasyAbp.Abp.DynamicPermission.Localization;
using Volo.Abp.AspNetCore.Components;

namespace EasyAbp.Abp.DynamicPermission.Blazor.Server.Host
{
    public abstract class DynamicPermissionComponentBase : AbpComponentBase
    {
        protected DynamicPermissionComponentBase()
        {
            LocalizationResource = typeof(DynamicPermissionResource);
        }
    }
}
