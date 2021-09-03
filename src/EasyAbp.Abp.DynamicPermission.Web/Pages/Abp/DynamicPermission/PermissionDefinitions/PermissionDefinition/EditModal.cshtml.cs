using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using EasyAbp.Abp.DynamicPermission.PermissionDefinitions;
using EasyAbp.Abp.DynamicPermission.PermissionDefinitions.Dtos;
using EasyAbp.Abp.DynamicPermission.Web.Pages.Abp.DynamicPermission.PermissionDefinitions.PermissionDefinition.ViewModels;

namespace EasyAbp.Abp.DynamicPermission.Web.Pages.Abp.DynamicPermission.PermissionDefinitions.PermissionDefinition
{
    public class EditModalModel : DynamicPermissionPageModel
    {
        [HiddenInput]
        [BindProperty(SupportsGet = true)]
        public PermissionDefinitionKey Id { get; set; }

        [BindProperty]
        public CreateEditPermissionDefinitionViewModel ViewModel { get; set; }

        private readonly IPermissionDefinitionAppService _service;

        public EditModalModel(IPermissionDefinitionAppService service)
        {
            _service = service;
        }

        public virtual async Task OnGetAsync()
        {
            var dto = await _service.GetAsync(Id);
            ViewModel = ObjectMapper.Map<PermissionDefinitionDto, CreateEditPermissionDefinitionViewModel>(dto);
        }

        public virtual async Task<IActionResult> OnPostAsync()
        {
            var dto = ObjectMapper.Map<CreateEditPermissionDefinitionViewModel, CreateUpdatePermissionDefinitionDto>(ViewModel);
            await _service.UpdateAsync(Id, dto);
            return NoContent();
        }
    }
}