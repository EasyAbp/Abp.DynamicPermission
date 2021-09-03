using EasyAbp.Abp.DynamicPermission.EntityFrameworkCore;
using Volo.Abp.Modularity;

namespace EasyAbp.Abp.DynamicPermission
{
    /* Domain tests are configured to use the EF Core provider.
     * You can switch to MongoDB, however your domain tests should be
     * database independent anyway.
     */
    [DependsOn(
        typeof(DynamicPermissionEntityFrameworkCoreTestModule)
        )]
    public class DynamicPermissionDomainTestModule : AbpModule
    {
        
    }
}
