using System;

using System.ComponentModel.DataAnnotations;

namespace EasyAbp.Abp.DynamicPermission.Web.Pages.Abp.DynamicPermission.PermissionGrants.PermissionGrant.ViewModels
{
    public class CreateEditPermissionGrantViewModel
    {
        [Display(Name = "PermissionGrantName")]
        public string Name { get; set; }

        [Display(Name = "PermissionGrantProviderName")]
        public string ProviderName { get; set; }

        [Display(Name = "PermissionGrantProviderKey")]
        public string ProviderKey { get; set; }
    }
}