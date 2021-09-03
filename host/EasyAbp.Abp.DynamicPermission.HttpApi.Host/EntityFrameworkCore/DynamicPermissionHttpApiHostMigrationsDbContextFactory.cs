using System.IO;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace EasyAbp.Abp.DynamicPermission.EntityFrameworkCore
{
    public class DynamicPermissionHttpApiHostMigrationsDbContextFactory : IDesignTimeDbContextFactory<DynamicPermissionHttpApiHostMigrationsDbContext>
    {
        public DynamicPermissionHttpApiHostMigrationsDbContext CreateDbContext(string[] args)
        {
            var configuration = BuildConfiguration();

            var builder = new DbContextOptionsBuilder<DynamicPermissionHttpApiHostMigrationsDbContext>()
                .UseSqlServer(configuration.GetConnectionString("DynamicPermission"));

            return new DynamicPermissionHttpApiHostMigrationsDbContext(builder.Options);
        }

        private static IConfigurationRoot BuildConfiguration()
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: false);

            return builder.Build();
        }
    }
}
