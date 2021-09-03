using System;
using System.Threading.Tasks;
using EasyAbp.Abp.DynamicPermission.PermissionDefinitions;
using Volo.Abp.Domain.Repositories;
using Xunit;

namespace EasyAbp.Abp.DynamicPermission.EntityFrameworkCore.PermissionDefinitions
{
    public class PermissionDefinitionRepositoryTests : DynamicPermissionEntityFrameworkCoreTestBase
    {
        private readonly IPermissionDefinitionRepository _permissionDefinitionRepository;

        public PermissionDefinitionRepositoryTests()
        {
            _permissionDefinitionRepository = GetRequiredService<IPermissionDefinitionRepository>();
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
