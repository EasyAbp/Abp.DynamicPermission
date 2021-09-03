using EasyAbp.Abp.DynamicPermission.PermissionGrants;
using EasyAbp.Abp.DynamicPermission.PermissionDefinitions;
using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.EntityFrameworkCore;
using Volo.Abp.Modularity;

namespace EasyAbp.Abp.DynamicPermission.EntityFrameworkCore
{
    [DependsOn(
        typeof(AbpDynamicPermissionDomainModule),
        typeof(AbpEntityFrameworkCoreModule)
    )]
    public class AbpDynamicPermissionEntityFrameworkCoreModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            context.Services.AddAbpDbContext<DynamicPermissionDbContext>(options =>
            {
                /* Add custom repositories here. Example:
                 * options.AddRepository<Question, EfCoreQuestionRepository>();
                 */
                options.AddRepository<PermissionDefinition, PermissionDefinitionRepository>();
                options.AddRepository<PermissionGrant, PermissionGrantRepository>();
            });
        }
    }
}
