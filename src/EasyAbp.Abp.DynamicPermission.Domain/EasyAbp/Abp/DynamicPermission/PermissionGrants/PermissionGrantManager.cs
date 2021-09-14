using System.Threading.Tasks;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Guids;
using Volo.Abp.MultiTenancy;
using Volo.Abp.Uow;

namespace EasyAbp.Abp.DynamicPermission.PermissionGrants
{
    [UnitOfWork]
    public class PermissionGrantManager : IPermissionGrantManager, ITransientDependency
    {
        private readonly IGuidGenerator _guidGenerator;
        private readonly ICurrentTenant _currentTenant;
        private readonly IPermissionGrantRepository _permissionGrantRepository;

        public PermissionGrantManager(
            IGuidGenerator guidGenerator,
            ICurrentTenant currentTenant,
            IPermissionGrantRepository permissionGrantRepository)
        {
            _guidGenerator = guidGenerator;
            _currentTenant = currentTenant;
            _permissionGrantRepository = permissionGrantRepository;
        }

        public virtual async Task<PermissionGrant> TryGrantAsync(string permissionName, string providerName,
            string providerKey)
        {
            var grant = await _permissionGrantRepository.FindAsync(permissionName, permissionName, providerKey);

            if (grant != null)
            {
                return grant;
            }
            
            grant = new PermissionGrant(
                _guidGenerator.Create(),
                _currentTenant.Id,
                permissionName,
                providerName,
                providerKey);

            return await _permissionGrantRepository.InsertAsync(grant, true);
        }

        public virtual async Task TryCancelGrantAsync(string permissionName, string providerName,
            string providerKey)
        {
            var grant = await _permissionGrantRepository.FindAsync(permissionName, permissionName, providerKey);

            if (grant == null)
            {
                return;
            }
            
            await _permissionGrantRepository.DeleteAsync(grant, true);
        }
    }
}