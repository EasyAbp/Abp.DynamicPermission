using Shouldly;
using System.Threading.Tasks;
using Xunit;

namespace EasyAbp.Abp.DynamicPermission.PermissionDefinitions
{
    public class PermissionDefinitionAppServiceTests : DynamicPermissionApplicationTestBase
    {
        private readonly IPermissionDefinitionAppService _permissionDefinitionAppService;

        public PermissionDefinitionAppServiceTests()
        {
            _permissionDefinitionAppService = GetRequiredService<IPermissionDefinitionAppService>();
        }

        /*
        [Fact]
        public async Task Test1()
        {
            // Arrange

            // Act

            // Assert
        }
        */
    }
}
