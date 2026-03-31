using System;
using System.Collections.Generic;
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

    public Task<List<UserFinderResult>> SearchUserAsync(string filter, int page = 1)
    {
        return Task.FromResult(new List<UserFinderResult>());
    }

    public Task<List<RoleFinderResult>> SearchRoleAsync(string filter, int page = 1)
    {
        return Task.FromResult(new List<RoleFinderResult>());
    }

    public Task<List<UserFinderResult>> SearchUserByIdsAsync(Guid[] ids)
    {
        return Task.FromResult(new List<UserFinderResult>());
    }

    public Task<List<RoleFinderResult>> SearchRoleByNamesAsync(string[] names)
    {
        return Task.FromResult(new List<RoleFinderResult>());
    }
}