using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.Domain;
using Volo.Abp.Modularity;
using Volo.Abp.PermissionManagement;

namespace EasyAbp.Abp.DynamicPermission
{
    [DependsOn(
        typeof(AbpDddDomainModule),
        typeof(AbpPermissionManagementDomainModule),
        typeof(AbpDynamicPermissionDomainSharedModule)
    )]
    public class AbpDynamicPermissionDomainModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            context.Services.Configure<PermissionManagementOptions>(options =>
            {
                options.IsDynamicPermissionStoreEnabled = true;
            });
        }
    }
}