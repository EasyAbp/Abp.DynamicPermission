using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Volo.Abp.Caching;
using Volo.Abp.DependencyInjection;

namespace EasyAbp.Abp.DynamicPermission.PermissionDefinitions
{
    public class DynamicPermissionDefinitionStore : IDynamicPermissionDefinitionStore, ITransientDependency
    {
        public static readonly string CacheKey = string.Empty;
        
        protected IDistributedCache<DynamicPermissionDefinitionCacheItem> Cache { get; }
        protected IPermissionDefinitionRepository PermissionDefinitionRepository { get; }
        
        public DynamicPermissionDefinitionStore(
            IDistributedCache<DynamicPermissionDefinitionCacheItem> cache,
            IPermissionDefinitionRepository permissionDefinitionRepository)
        {
            Cache = cache;
            PermissionDefinitionRepository = permissionDefinitionRepository;
        }
        
        public virtual async Task<Dictionary<string, PermissionDefinition>> GetDictionaryAsync()
        {
            return (await Cache.GetOrAddAsync(CacheKey,
                    async () =>
                        new DynamicPermissionDefinitionCacheItem((await PermissionDefinitionRepository.GetListAsync()).ToDictionary(x => x.Name, x => x))))
                .PermissionDefinitions;
        }

        public virtual async Task<PermissionDefinition> GetAsync(string name)
        {
            return (await GetDictionaryAsync()).GetOrDefault(name);
        }
    }
}