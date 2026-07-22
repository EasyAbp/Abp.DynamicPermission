using EasyAbp.Abp.DynamicPermission.PermissionDefinitions.Dtos;
using Shouldly;
using Volo.Abp.ObjectMapping;
using Xunit;

namespace EasyAbp.Abp.DynamicPermission.PermissionDefinitions
{
    public class PermissionDefinitionAppServiceTests : DynamicPermissionApplicationTestBase
    {
        private readonly IPermissionDefinitionAppService _permissionDefinitionAppService;
        private readonly IObjectMapper _objectMapper;

        public PermissionDefinitionAppServiceTests()
        {
            _permissionDefinitionAppService = GetRequiredService<IPermissionDefinitionAppService>();
            _objectMapper = GetRequiredService<IObjectMapper>();
        }

        [Fact]
        public void Should_Map_PermissionDefinition_To_Dto()
        {
            // Arrange
            var entity = new PermissionDefinition(
                name: "MyGroup.MyPermission",
                displayName: "My Permission",
                description: "A test permission definition.",
                isPublic: true);

            // Act
            var dto = _objectMapper.Map<PermissionDefinition, PermissionDefinitionDto>(entity);

            // Assert
            dto.ShouldNotBeNull();
            dto.Name.ShouldBe(entity.Name);
            dto.DisplayName.ShouldBe(entity.DisplayName);
            dto.Description.ShouldBe(entity.Description);
            dto.IsPublic.ShouldBe(entity.IsPublic);
        }
    }
}
