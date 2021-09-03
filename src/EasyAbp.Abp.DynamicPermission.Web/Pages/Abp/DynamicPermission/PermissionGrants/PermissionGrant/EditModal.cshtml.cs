using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using EasyAbp.Abp.DynamicPermission.PermissionGrants;
using EasyAbp.Abp.DynamicPermission.PermissionGrants.Dtos;
using EasyAbp.Abp.DynamicPermission.Web.Pages.Abp.DynamicPermission.PermissionGrants.PermissionGrant.ViewModels;

namespace EasyAbp.Abp.DynamicPermission.Web.Pages.Abp.DynamicPermission.PermissionGrants.PermissionGrant
{
    public class EditModalModel : DynamicPermissionPageModel
    {
        [HiddenInput]
        [BindProperty(SupportsGet = true)]
        public Guid Id { get; set; }

        [BindProperty]
        public CreateEditPermissionGrantViewModel ViewModel { get; set; }

        private readonly IPermissionGrantAppService _service;

        public EditModalModel(IPermissionGrantAppService service)
        {
            _service = service;
        }

        public virtual async Task OnGetAsync()
        {
            var dto = await _service.GetAsync(Id);
            ViewModel = ObjectMapper.Map<PermissionGrantDto, CreateEditPermissionGrantViewModel>(dto);
        }

        public virtual async Task<IActionResult> OnPostAsync()
        {
            var dto = ObjectMapper.Map<CreateEditPermissionGrantViewModel, CreateUpdatePermissionGrantDto>(ViewModel);
            await _service.UpdateAsync(Id, dto);
            return NoContent();
        }
    }
}