using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using EasyAbp.Abp.DynamicPermission.PermissionDefinitions;
using EasyAbp.Abp.DynamicPermission.PermissionDefinitions.Dtos;
using EasyAbp.Abp.DynamicPermission.Web.Pages.Abp.DynamicPermission.PermissionDefinitions.PermissionDefinition.ViewModels;

namespace EasyAbp.Abp.DynamicPermission.Web.Pages.Abp.DynamicPermission.PermissionDefinitions.PermissionDefinition
{
    public class CreateModalModel : DynamicPermissionPageModel
    {
        [BindProperty]
        public CreateEditPermissionDefinitionViewModel ViewModel { get; set; }

        private readonly IPermissionDefinitionAppService _service;

        public CreateModalModel(IPermissionDefinitionAppService service)
        {
            _service = service;
        }

        public virtual async Task<IActionResult> OnPostAsync()
        {
            var dto = ObjectMapper.Map<CreateEditPermissionDefinitionViewModel, CreateUpdatePermissionDefinitionDto>(ViewModel);
            await _service.CreateAsync(dto);
            return NoContent();
        }
    }
}