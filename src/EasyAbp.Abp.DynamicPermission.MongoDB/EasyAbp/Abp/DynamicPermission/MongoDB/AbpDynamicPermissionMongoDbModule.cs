using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.Modularity;
using Volo.Abp.MongoDB;

namespace EasyAbp.Abp.DynamicPermission.MongoDB
{
    [DependsOn(
        typeof(AbpDynamicPermissionDomainModule),
        typeof(AbpMongoDbModule)
        )]
    public class AbpDynamicPermissionMongoDbModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            context.Services.AddMongoDbContext<DynamicPermissionMongoDbContext>(options =>
            {
                /* Add custom repositories here. Example:
                 * options.AddRepository<Question, MongoQuestionRepository>();
                 */
            });
        }
    }
}
