using System.Threading.Tasks;

namespace EasyAbp.Abp.DynamicPermission.Web.Pages.Abp.DynamicPermission.PermissionDefinitions.PermissionDefinition
{
    public class IndexModel : DynamicPermissionPageModel
    {
        public virtual async Task OnGetAsync()
        {
            await Task.CompletedTask;
        }
    }
}
