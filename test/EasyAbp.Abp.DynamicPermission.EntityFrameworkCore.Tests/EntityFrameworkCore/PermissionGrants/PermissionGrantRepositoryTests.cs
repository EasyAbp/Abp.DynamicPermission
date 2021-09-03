using System;
using System.Threading.Tasks;
using EasyAbp.Abp.DynamicPermission.PermissionGrants;
using Volo.Abp.Domain.Repositories;
using Xunit;

namespace EasyAbp.Abp.DynamicPermission.EntityFrameworkCore.PermissionGrants
{
    public class PermissionGrantRepositoryTests : DynamicPermissionEntityFrameworkCoreTestBase
    {
        private readonly IPermissionGrantRepository _permissionGrantRepository;

        public PermissionGrantRepositoryTests()
        {
            _permissionGrantRepository = GetRequiredService<IPermissionGrantRepository>();
        }

        /*
        [Fact]
        public async Task Test1()
        {
            await WithUnitOfWorkAsync(async () =>
            {
                // Arrange

                // Act

                //Assert
            });
        }
        */
    }
}
