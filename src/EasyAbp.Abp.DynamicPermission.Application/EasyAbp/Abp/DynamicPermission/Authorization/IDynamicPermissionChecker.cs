using System.Security.Claims;
using System.Threading.Tasks;
using JetBrains.Annotations;

namespace EasyAbp.Abp.DynamicPermission.Authorization
{
    public interface IDynamicPermissionChecker
    {
        Task<bool> IsGrantedAsync([NotNull] string name);

        Task<bool> IsGrantedAsync(ClaimsPrincipal claimsPrincipal, string name);
    }
}