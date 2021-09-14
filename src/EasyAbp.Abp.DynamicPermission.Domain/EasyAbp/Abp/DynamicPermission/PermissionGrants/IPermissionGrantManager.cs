using System.Threading.Tasks;

namespace EasyAbp.Abp.DynamicPermission.PermissionGrants
{
    public interface IPermissionGrantManager
    {
        Task<PermissionGrant> TryGrantAsync(string permissionName, string providerName, string providerKey);
        
        Task TryCancelGrantAsync(string permissionName, string providerName, string providerKey);
    }
}