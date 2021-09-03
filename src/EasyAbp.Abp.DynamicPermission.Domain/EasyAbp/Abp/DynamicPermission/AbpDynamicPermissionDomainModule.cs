using Volo.Abp.Domain;
using Volo.Abp.Modularity;

namespace EasyAbp.Abp.DynamicPermission
{
    [DependsOn(
        typeof(AbpDddDomainModule),
        typeof(AbpDynamicPermissionDomainSharedModule)
    )]
    public class AbpDynamicPermissionDomainModule : AbpModule
    {

    }
}
