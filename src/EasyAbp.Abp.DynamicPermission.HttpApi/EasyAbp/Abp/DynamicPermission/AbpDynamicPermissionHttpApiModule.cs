﻿using Localization.Resources.AbpUi;
using EasyAbp.Abp.DynamicPermission.Localization;
using Volo.Abp.AspNetCore.Mvc;
using Volo.Abp.Localization;
using Volo.Abp.Modularity;
using Microsoft.Extensions.DependencyInjection;

namespace EasyAbp.Abp.DynamicPermission
{
    [DependsOn(
        typeof(AbpDynamicPermissionApplicationContractsModule),
        typeof(AbpAspNetCoreMvcModule))]
    public class AbpDynamicPermissionHttpApiModule : AbpModule
    {
        public override void PreConfigureServices(ServiceConfigurationContext context)
        {
            PreConfigure<IMvcBuilder>(mvcBuilder =>
            {
                mvcBuilder.AddApplicationPartIfNotExists(typeof(AbpDynamicPermissionHttpApiModule).Assembly);
            });
        }

        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            Configure<AbpLocalizationOptions>(options =>
            {
                options.Resources
                    .Get<DynamicPermissionResource>()
                    .AddBaseTypes(typeof(AbpUiResource));
            });
        }
    }
}
