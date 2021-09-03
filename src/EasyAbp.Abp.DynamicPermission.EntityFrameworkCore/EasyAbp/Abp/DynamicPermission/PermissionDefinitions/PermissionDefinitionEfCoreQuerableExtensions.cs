using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace EasyAbp.Abp.DynamicPermission.PermissionDefinitions
{
    public static class PermissionDefinitionEfCoreQueryableExtensions
    {
        public static IQueryable<PermissionDefinition> IncludeDetails(this IQueryable<PermissionDefinition> queryable, bool include = true)
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