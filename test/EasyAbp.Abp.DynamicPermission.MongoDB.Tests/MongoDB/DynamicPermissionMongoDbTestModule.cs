using System;
using Volo.Abp.Data;
using Volo.Abp.Modularity;
using Volo.Abp.Uow;

namespace EasyAbp.Abp.DynamicPermission.MongoDB
{
    [DependsOn(
        typeof(DynamicPermissionTestBaseModule),
        typeof(AbpDynamicPermissionMongoDbModule)
        )]
    public class DynamicPermissionMongoDbTestModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            Configure<AbpDbConnectionOptions>(options =>
            {
                options.ConnectionStrings.Default = MongoDbFixture.GetRandomConnectionString();
            });
        }
    }
}
