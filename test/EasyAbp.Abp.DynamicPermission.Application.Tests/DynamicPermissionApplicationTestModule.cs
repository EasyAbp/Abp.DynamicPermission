using Volo.Abp.Modularity;
using Volo.Abp.PermissionManagement;

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
