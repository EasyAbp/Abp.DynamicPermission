using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;

namespace EasyAbp.Abp.DynamicPermission.PermissionGrants
{
    public interface IPermissionGrantRepository : IRepository<PermissionGrant, Guid>
    {
        Task<PermissionGrant> FindAsync(
            string name,
            string providerName,
            string providerKey,
            CancellationToken cancellationToken = default
        );

        Task<List<PermissionGrant>> GetListAsync(
            string providerName,
            string providerKey,
            CancellationToken cancellationToken = default
        );

        Task<List<PermissionGrant>> GetListAsync(
            string[] names,
            string providerName,
            string providerKey,
            CancellationToken cancellationToken = default
        );
    }
}