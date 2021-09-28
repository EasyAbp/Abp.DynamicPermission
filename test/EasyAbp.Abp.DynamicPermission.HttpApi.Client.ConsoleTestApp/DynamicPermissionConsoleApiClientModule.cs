using Volo.Abp.Http.Client.IdentityModel;
using Volo.Abp.Modularity;

namespace EasyAbp.Abp.DynamicPermission
{
    [DependsOn(
        typeof(AbpDynamicPermissionHttpApiClientModule),
        typeof(AbpHttpClientIdentityModelModule)
        )]
    public class DynamicPermissionConsoleApiClientModule : AbpModule
    {
        
    }
}
