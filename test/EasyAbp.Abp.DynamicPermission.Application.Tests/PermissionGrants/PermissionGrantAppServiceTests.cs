using Shouldly;
using System.Threading.Tasks;
using Xunit;

namespace EasyAbp.Abp.DynamicPermission.PermissionGrants
{
    public class PermissionGrantAppServiceTests : DynamicPermissionApplicationTestBase
    {
        private readonly IPermissionGrantAppService _permissionGrantAppService;

        public PermissionGrantAppServiceTests()
        {
            _permissionGrantAppService = GetRequiredService<IPermissionGrantAppService>();
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
