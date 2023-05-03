﻿using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage;
using Volo.Abp.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore.Sqlite;
using Volo.Abp.Modularity;
using Volo.Abp.Uow;
using Volo.Abp.PermissionManagement.EntityFrameworkCore;

namespace EasyAbp.Abp.DynamicPermission.EntityFrameworkCore
{
    [DependsOn(
        typeof(DynamicPermissionTestBaseModule),
        typeof(AbpDynamicPermissionEntityFrameworkCoreModule),
        typeof(AbpEntityFrameworkCoreSqliteModule),
        typeof(AbpPermissionManagementEntityFrameworkCoreModule)
    )]
    public class DynamicPermissionEntityFrameworkCoreTestModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            context.Services.AddAlwaysDisableUnitOfWorkTransaction();
            var sqliteConnection = CreateDatabaseAndGetConnection();

            Configure<AbpDbContextOptions>(options =>
            {
                options.Configure(abpDbContextConfigurationContext =>
                {
                    abpDbContextConfigurationContext.DbContextOptions.UseSqlite(sqliteConnection);
                });
            });
        }
        
        private static SqliteConnection CreateDatabaseAndGetConnection()
        {
            var connection = new SqliteConnection("Data Source=:memory:");
            connection.Open();

            new DynamicPermissionTestDbContext(
                new DbContextOptionsBuilder<DynamicPermissionTestDbContext>().UseSqlite(connection).Options
            ).GetService<IRelationalDatabaseCreator>().CreateTables();
            
            return connection;
        }
    }
}
