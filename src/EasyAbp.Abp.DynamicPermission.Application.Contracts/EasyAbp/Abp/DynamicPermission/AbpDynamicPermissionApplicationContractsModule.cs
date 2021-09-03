using Volo.Abp.Application;
using Volo.Abp.Modularity;
using Volo.Abp.Authorization;

namespace EasyAbp.Abp.DynamicPermission
{
    [DependsOn(
        typeof(AbpDynamicPermissionDomainSharedModule),
        typeof(AbpDddApplicationContractsModule),
        typeof(AbpAuthorizationModule)
        )]
    public class AbpDynamicPermissionApplicationContractsModule : AbpModule
    {

    }
}
