using Microsoft.EntityFrameworkCore;
using Volo.Abp.Data;
using Volo.Abp.EntityFrameworkCore;
using EasyAbp.Abp.DynamicPermission.PermissionDefinitions;

namespace EasyAbp.Abp.DynamicPermission.EntityFrameworkCore
{
    [ConnectionStringName(DynamicPermissionDbProperties.ConnectionStringName)]
    public interface IDynamicPermissionDbContext : IEfCoreDbContext
    {
        /* Add DbSet for each Aggregate Root here. Example:
         * DbSet<Question> Questions { get; }
         */
        DbSet<PermissionDefinition> PermissionDefinitions { get; set; }
    }
}
