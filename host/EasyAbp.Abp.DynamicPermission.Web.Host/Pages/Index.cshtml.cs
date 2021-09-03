using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;

namespace EasyAbp.Abp.DynamicPermission.Pages
{
    public class IndexModel : DynamicPermissionPageModel
    {
        public void OnGet()
        {
            
        }

        public async Task OnPostLoginAsync()
        {
            await HttpContext.ChallengeAsync("oidc");
        }
    }
}