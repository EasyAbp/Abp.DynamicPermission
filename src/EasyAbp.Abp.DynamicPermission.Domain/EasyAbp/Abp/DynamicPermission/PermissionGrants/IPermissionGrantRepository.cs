using System;
using System.Threading.Tasks;
using JetBrains.Annotations;
using Volo.Abp.Domain.Repositories;

namespace EasyAbp.Abp.DynamicPermission.PermissionGrants
{
    public interface IPermissionGrantRepository : IRepository<PermissionGrant, Guid>
    {
        Task<PermissionGrant> FindAsync([NotNull] string name, [NotNull] string providerName,
            [CanBeNull] string providerKey);
    }
}