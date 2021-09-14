using System.Threading.Tasks;
using EasyAbp.Abp.DynamicPermission.PermissionDefinitions;
using EasyAbp.Abp.DynamicPermission.PermissionGrants;
using Microsoft.AspNetCore.Authorization;
using Shouldly;
using Volo.Abp.Users;
using Xunit;

namespace EasyAbp.Abp.DynamicPermission.Authorization
{
    public class AuthorizationTests : DynamicPermissionApplicationTestBase
    {
        private readonly ICurrentUser _currentUser;
        private readonly IAuthorizationService _authorizationService;
        private readonly IPermissionGrantManager _permissionGrantManager;
        private readonly IPermissionDefinitionRepository _permissionDefinitionRepository;

        public AuthorizationTests()
        {
            _currentUser = GetRequiredService<ICurrentUser>();
            _authorizationService = GetRequiredService<IAuthorizationService>();
            _permissionGrantManager = GetRequiredService<IPermissionGrantManager>();
            _permissionDefinitionRepository = GetRequiredService<IPermissionDefinitionRepository>();
        }

         [Fact]
         public async Task Should_Have_Permission_Grant()
         {
             // Arrange
             
             const string permissionName = "Permission1";
             
             await _permissionDefinitionRepository.InsertAsync(
                 new PermissionDefinition(permissionName, "Test permission 1", "A permission for test.", true));

             await _permissionGrantManager.TryGrantAsync(permissionName,
                 UserDynamicPermissionValueProvider.ProviderName, _currentUser.GetId().ToString());

             // Act

             var isGranted = await _authorizationService.IsGrantedAsync(null,
                 new DynamicPermissionAuthorizationRequirement(permissionName));

             // Assert
             
             isGranted.ShouldBe(true);
         }
         
         [Fact]
         public async Task Should_Not_Have_Permission_Grant()
         {
             // Arrange
             
             const string permissionName = "Permission2";
             
             await _permissionDefinitionRepository.InsertAsync(
                 new PermissionDefinition(permissionName, "Test permission 2", "A permission for test.", true));

             await _permissionGrantManager.TryCancelGrantAsync(permissionName,
                 UserDynamicPermissionValueProvider.ProviderName, _currentUser.GetId().ToString());

             // Act

             var isGranted = await _authorizationService.IsGrantedAsync(null,
                 new DynamicPermissionAuthorizationRequirement(permissionName));

             // Assert
             
             isGranted.ShouldBe(false);
         }
    }
}
