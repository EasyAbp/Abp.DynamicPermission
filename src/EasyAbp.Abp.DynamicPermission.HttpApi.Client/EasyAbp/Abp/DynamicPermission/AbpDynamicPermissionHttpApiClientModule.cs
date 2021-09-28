using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.Http.Client;
using Volo.Abp.Modularity;

namespace EasyAbp.Abp.DynamicPermission
{
    [DependsOn(
        typeof(AbpDynamicPermissionApplicationContractsModule),
        typeof(AbpHttpClientModule))]
    public class AbpDynamicPermissionHttpApiClientModule : AbpModule
    {
        public const string RemoteServiceName = "EasyAbpAbpDynamicPermission";

        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            context.Services.AddHttpClientProxies(
                typeof(AbpDynamicPermissionApplicationContractsModule).Assembly,
                RemoteServiceName
            );
        }
    }
}
