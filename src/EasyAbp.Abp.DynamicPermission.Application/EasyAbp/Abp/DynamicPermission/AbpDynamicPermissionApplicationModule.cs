using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.AutoMapper;
using Volo.Abp.Modularity;
using Volo.Abp.Application;

namespace EasyAbp.Abp.DynamicPermission
{
    [DependsOn(
        typeof(AbpDynamicPermissionDomainModule),
        typeof(AbpDynamicPermissionApplicationContractsModule),
        typeof(AbpDddApplicationModule),
        typeof(AbpAutoMapperModule)
        )]
    public class AbpDynamicPermissionApplicationModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            context.Services.AddAutoMapperObjectMapper<AbpDynamicPermissionApplicationModule>();
            Configure<AbpAutoMapperOptions>(options =>
            {
                options.AddMaps<AbpDynamicPermissionApplicationModule>(validate: true);
            });
        }
    }
}
