using Volo.Abp.Modularity;

namespace EasyAbp.Abp.DynamicPermission
{
    [DependsOn(
        typeof(AbpDynamicPermissionApplicationModule),
        typeof(DynamicPermissionDomainTestModule)
        )]
    public class DynamicPermissionApplicationTestModule : AbpModule
    {

    }
}
