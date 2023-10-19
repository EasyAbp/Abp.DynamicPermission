using System;
using System.Threading.Tasks;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Identity;

namespace EasyAbp.Abp.DynamicPermission;

public class FakeUserRoleFinder : IUserRoleFinder, ITransientDependency
{
    public Task<string[]> GetRolesAsync(Guid userId)
    {
        return GetRoleNamesAsync(userId);
    }

    public Task<string[]> GetRoleNamesAsync(Guid userId)
    {
        return Task.FromResult(new[] { "normal-user" });
    }
}