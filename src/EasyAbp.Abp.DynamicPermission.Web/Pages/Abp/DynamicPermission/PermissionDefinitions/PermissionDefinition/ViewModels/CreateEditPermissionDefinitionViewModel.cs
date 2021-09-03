using System;

using System.ComponentModel.DataAnnotations;

namespace EasyAbp.Abp.DynamicPermission.Web.Pages.Abp.DynamicPermission.PermissionDefinitions.PermissionDefinition.ViewModels
{
    public class CreateEditPermissionDefinitionViewModel
    {
        [Display(Name = "PermissionDefinitionName")]
        public string Name { get; set; }

        [Display(Name = "PermissionDefinitionDisplayName")]
        public string DisplayName { get; set; }

        [Display(Name = "PermissionDefinitionDescription")]
        public string Description { get; set; }

        [Display(Name = "PermissionDefinitionIsPublic")]
        public bool IsPublic { get; set; }
    }
}