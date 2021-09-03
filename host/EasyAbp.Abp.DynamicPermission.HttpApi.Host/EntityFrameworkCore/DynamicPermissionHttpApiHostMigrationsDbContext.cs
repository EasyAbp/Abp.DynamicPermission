using Microsoft.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;

namespace EasyAbp.Abp.DynamicPermission.EntityFrameworkCore
{
    public class DynamicPermissionHttpApiHostMigrationsDbContext : AbpDbContext<DynamicPermissionHttpApiHostMigrationsDbContext>
    {
        public DynamicPermissionHttpApiHostMigrationsDbContext(DbContextOptions<DynamicPermissionHttpApiHostMigrationsDbContext> options)
            : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ConfigureAbpDynamicPermission();
        }
    }
}
