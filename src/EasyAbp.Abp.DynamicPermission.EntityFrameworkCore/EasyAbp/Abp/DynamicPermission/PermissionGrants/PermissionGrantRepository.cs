using System;
using System.Linq;
using System.Threading.Tasks;
using EasyAbp.Abp.DynamicPermission.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;

namespace EasyAbp.Abp.DynamicPermission.PermissionGrants
{
    public class PermissionGrantRepository : EfCoreRepository<IDynamicPermissionDbContext, PermissionGrant, Guid>, IPermissionGrantRepository
    {
        public PermissionGrantRepository(IDbContextProvider<IDynamicPermissionDbContext> dbContextProvider) : base(dbContextProvider)
        {
        }

        public virtual async Task<PermissionGrant> FindAsync(string name, string providerName, string providerKey)
        {
            return await (await GetDbSetAsync())
                .Where(x => x.Name == name && x.ProviderName == providerName && x.ProviderKey == providerKey)
                .SingleOrDefaultAsync();
        }
    }
}