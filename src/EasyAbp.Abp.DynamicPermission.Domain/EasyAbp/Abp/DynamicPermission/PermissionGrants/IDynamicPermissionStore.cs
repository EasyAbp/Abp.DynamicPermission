using System.Threading.Tasks;
using JetBrains.Annotations;

namespace EasyAbp.Abp.DynamicPermission.PermissionGrants
{
    public interface IDynamicPermissionStore
    {
        Task<bool> IsGrantedAsync(
            [NotNull] string name,
            [CanBeNull] string providerName,
            [CanBeNull] string providerKey
        );
    }
}