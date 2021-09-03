using EasyAbp.Abp.DynamicPermission.Localization;
using Volo.Abp.AspNetCore.Mvc.UI.RazorPages;

namespace EasyAbp.Abp.DynamicPermission.Pages
{
    public abstract class DynamicPermissionPageModel : AbpPageModel
    {
        protected DynamicPermissionPageModel()
        {
            LocalizationResourceType = typeof(DynamicPermissionResource);
        }
    }
}