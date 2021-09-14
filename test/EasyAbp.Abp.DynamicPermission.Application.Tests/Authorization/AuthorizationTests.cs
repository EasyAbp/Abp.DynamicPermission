using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Shouldly;
using Volo.Abp.Authorization.Permissions;
using Volo.Abp.PermissionManagement;
using Volo.Abp.Users;
using Xunit;

namespace EasyAbp.Abp.DynamicPermission.Authorization
{
    public class AuthorizationTests : DynamicPermissionApplicationTestBase
    {
        private readonly ICurrentUser _currentUser;
        private readonly IAuthorizationService _authorizationService;
        private readonly IPermissionManager _permissionManager;

        public AuthorizationTests()
        {
            _currentUser = GetRequiredService<ICurrentUser>();
            _authorizationService = GetRequiredService<IAuthorizationService>();
            _permissionManager = GetRequiredService<IPermissionManager>();
        }

         [Fact]
         public async Task Should_Have_Permission_Grant()
         {
             // Arrange

             await _permissionManager.SetAsync(DynamicPermissionTestConsts.Permission1Name,
                 UserPermissionValueProvider.ProviderName, _currentUser.GetId().ToString(), true);

             // Act

             var isGranted = await _authorizationService.IsGrantedAsync(DynamicPermissionTestConsts.Permission1Name);

             // Assert
             
             isGranted.ShouldBe(true);
         }
         
         [Fact]
         public async Task Should_Not_Have_Permission_Grant()
         {
             // Arrange
             
             await _permissionManager.SetAsync(DynamicPermissionTestConsts.Permission2Name,
                 UserPermissionValueProvider.ProviderName, _currentUser.GetId().ToString(), false);

             // Act

             var isGranted = await _authorizationService.IsGrantedAsync(DynamicPermissionTestConsts.Permission2Name);

             // Assert
             
             isGranted.ShouldBe(false);
         }
    }
}
