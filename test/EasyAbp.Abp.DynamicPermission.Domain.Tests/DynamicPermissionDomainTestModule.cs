using EasyAbp.Abp.DynamicPermission.EntityFrameworkCore;
using Volo.Abp.Modularity;
using Volo.Abp.PermissionManagement;
using Volo.Abp.PermissionManagement.Identity;

namespace EasyAbp.Abp.DynamicPermission
{
    /* Domain tests are configured to use the EF Core provider.
     * You can switch to MongoDB, however your domain tests should be
     * database independent anyway.
     */
    [DependsOn(
        typeof(DynamicPermissionEntityFrameworkCoreTestModule),
        typeof(AbpPermissionManagementDomainModule),
        typeof(AbpPermissionManagementDomainIdentityModule)
    )]
    public class DynamicPermissionDomainTestModule : AbpModule
    {
        
    }
}
