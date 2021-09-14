using System.Collections.Generic;
using System.Threading.Tasks;
using JetBrains.Annotations;

namespace EasyAbp.Abp.DynamicPermission.PermissionDefinitions
{
    public interface IDynamicPermissionDefinitionStore
    {
        Task<Dictionary<string, PermissionDefinition>> GetDictionaryAsync();
        
        Task<PermissionDefinition> GetAsync([NotNull] string name);
    }
}