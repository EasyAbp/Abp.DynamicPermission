using System.Collections.Generic;
using System.Security.Claims;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Security.Claims;

namespace EasyAbp.Abp.DynamicPermission.Security
{
    [Dependency(ReplaceServices = true)]
    public class FakeCurrentPrincipalAccessor : ThreadCurrentPrincipalAccessor
    {
        protected override ClaimsPrincipal GetClaimsPrincipal()
        {
            return GetPrincipal();
        }

        private ClaimsPrincipal _principal;

        private ClaimsPrincipal GetPrincipal()
        {
            if (_principal == null)
            {
                lock (this)
                {
                    if (_principal == null)
                    {
                        _principal = new ClaimsPrincipal(
                            new ClaimsIdentity(
                                new List<Claim>
                                {
                                    new Claim(AbpClaimTypes.UserId, DynamicPermissionTestConsts.TestUserIdString),
                                    new Claim(AbpClaimTypes.UserName, DynamicPermissionTestConsts.TestUserName),
                                    new Claim(AbpClaimTypes.Email, DynamicPermissionTestConsts.TestUserEmail)
                                }
                            )
                        );
                    }
                }
            }

            return _principal;
        }
    }
}
