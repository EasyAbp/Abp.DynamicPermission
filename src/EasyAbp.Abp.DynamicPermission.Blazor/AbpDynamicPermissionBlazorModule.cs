using Microsoft.Extensions.DependencyInjection;
using EasyAbp.Abp.DynamicPermission.Blazor.Menus;
using Volo.Abp.AspNetCore.Components.Web.Theming;
using Volo.Abp.AspNetCore.Components.Web.Theming.Routing;
using Volo.Abp.AutoMapper;
using Volo.Abp.Modularity;
using Volo.Abp.UI.Navigation;

namespace EasyAbp.Abp.DynamicPermission.Blazor
{
    [DependsOn(
        typeof(AbpDynamicPermissionApplicationContractsModule),
        typeof(AbpAspNetCoreComponentsWebThemingModule),
        typeof(AbpAutoMapperModule)
        )]
    public class AbpDynamicPermissionBlazorModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            context.Services.AddAutoMapperObjectMapper<AbpDynamicPermissionBlazorModule>();

            Configure<AbpAutoMapperOptions>(options =>
            {
                options.AddProfile<DynamicPermissionBlazorAutoMapperProfile>(validate: true);
            });

            Configure<AbpNavigationOptions>(options =>
            {
                options.MenuContributors.Add(new DynamicPermissionMenuContributor());
            });

            Configure<AbpRouterOptions>(options =>
            {
                options.AdditionalAssemblies.Add(typeof(AbpDynamicPermissionBlazorModule).Assembly);
            });
        }
    }
}