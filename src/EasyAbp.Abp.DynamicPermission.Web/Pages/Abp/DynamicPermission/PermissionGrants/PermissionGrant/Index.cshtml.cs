using System.Threading.Tasks;
using EasyAbp.Abp.DynamicPermission.PermissionDefinitions;
using EasyAbp.Abp.DynamicPermission.PermissionDefinitions.Dtos;
using JetBrains.Annotations;

namespace EasyAbp.Abp.DynamicPermission.Web.Pages.Abp.DynamicPermission.PermissionGrants.PermissionGrant
{
    public class IndexModel : DynamicPermissionPageModel
    {
        private readonly IPermissionDefinitionAppService _permissionDefinitionAppService;
        public PermissionDefinitionDto PermissionDefinition { get; set; }

        public IndexModel(IPermissionDefinitionAppService permissionDefinitionAppService)
        {
            _permissionDefinitionAppService = permissionDefinitionAppService;
        }

        public virtual async Task OnGetAsync([NotNull] string name)
        {
            PermissionDefinition = await _permissionDefinitionAppService.GetAsync(new PermissionDefinitionKey(name));
        }
    }
}
