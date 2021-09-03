using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace EasyAbp.Abp.DynamicPermission.PermissionGrants
{
    public static class PermissionGrantEfCoreQueryableExtensions
    {
        public static IQueryable<PermissionGrant> IncludeDetails(this IQueryable<PermissionGrant> queryable, bool include = true)
        {
            if (!include)
            {
                return queryable;
            }

            return queryable
                // .Include(x => x.xxx) // TODO: AbpHelper generated
                ;
        }
    }
}