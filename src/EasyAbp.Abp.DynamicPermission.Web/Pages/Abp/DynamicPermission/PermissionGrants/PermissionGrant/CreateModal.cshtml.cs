using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using EasyAbp.Abp.DynamicPermission.PermissionGrants;
using EasyAbp.Abp.DynamicPermission.PermissionGrants.Dtos;
using EasyAbp.Abp.DynamicPermission.Web.Pages.Abp.DynamicPermission.PermissionGrants.PermissionGrant.ViewModels;
using JetBrains.Annotations;

namespace EasyAbp.Abp.DynamicPermission.Web.Pages.Abp.DynamicPermission.PermissionGrants.PermissionGrant
{
    public class CreateModalModel : DynamicPermissionPageModel
    {
        [BindProperty]
        public CreateEditPermissionGrantViewModel ViewModel { get; set; }

        private readonly IPermissionGrantAppService _service;

        public CreateModalModel(IPermissionGrantAppService service)
        {
            _service = service;
        }

        public virtual async Task OnGetAsync([CanBeNull] string name)
        {
            ViewModel = new CreateEditPermissionGrantViewModel
            {
                Name = name
            };
        }

        public virtual async Task<IActionResult> OnPostAsync()
        {
            var dto = ObjectMapper.Map<CreateEditPermissionGrantViewModel, CreateUpdatePermissionGrantDto>(ViewModel);
            await _service.CreateAsync(dto);
            return NoContent();
        }
    }
}