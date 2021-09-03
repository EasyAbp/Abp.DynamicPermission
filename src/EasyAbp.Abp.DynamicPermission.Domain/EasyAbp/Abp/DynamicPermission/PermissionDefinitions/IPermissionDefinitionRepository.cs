using System;
using Volo.Abp.Domain.Repositories;

namespace EasyAbp.Abp.DynamicPermission.PermissionDefinitions
{
    public interface IPermissionDefinitionRepository : IRepository<PermissionDefinition>
    {
    }
}