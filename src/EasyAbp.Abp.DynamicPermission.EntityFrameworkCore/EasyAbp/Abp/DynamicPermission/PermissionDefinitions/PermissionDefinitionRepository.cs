using System;
using EasyAbp.Abp.DynamicPermission.EntityFrameworkCore;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;

namespace EasyAbp.Abp.DynamicPermission.PermissionDefinitions
{
    public class PermissionDefinitionRepository : EfCoreRepository<IDynamicPermissionDbContext, PermissionDefinition>, IPermissionDefinitionRepository
    {
        public PermissionDefinitionRepository(IDbContextProvider<IDynamicPermissionDbContext> dbContextProvider) : base(dbContextProvider)
        {
        }
    }
}