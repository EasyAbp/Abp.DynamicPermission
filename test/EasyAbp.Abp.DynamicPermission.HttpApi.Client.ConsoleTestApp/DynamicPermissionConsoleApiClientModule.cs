using Volo.Abp.Http.Client.IdentityModel;
using Volo.Abp.Modularity;

namespace EasyAbp.Abp.DynamicPermission
{
    [DependsOn(
        typeof(DynamicPermissionHttpApiClientModule),
        typeof(AbpHttpClientIdentityModelModule)
        )]
    public class DynamicPermissionConsoleApiClientModule : AbpModule
    {
        
    }
}
