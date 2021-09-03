using Volo.Abp.AspNetCore.Components.Server.Theming;
using Volo.Abp.Modularity;

namespace EasyAbp.Abp.DynamicPermission.Blazor.Server
{
    [DependsOn(
        typeof(AbpAspNetCoreComponentsServerThemingModule),
        typeof(AbpDynamicPermissionBlazorModule)
        )]
    public class AbpDynamicPermissionBlazorServerModule : AbpModule
    {
        
    }
}