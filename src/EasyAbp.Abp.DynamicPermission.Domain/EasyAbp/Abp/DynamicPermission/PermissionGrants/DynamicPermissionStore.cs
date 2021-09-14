using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EasyAbp.Abp.DynamicPermission.PermissionDefinitions;
using Volo.Abp.Caching;
using Volo.Abp.DependencyInjection;

namespace EasyAbp.Abp.DynamicPermission.PermissionGrants
{
    public class DynamicPermissionStore : IDynamicPermissionStore, ITransientDependency
    {
        protected IDistributedCache<DynamicPermissionGrantCacheItem> Cache { get; }
        protected IDynamicPermissionDefinitionStore DynamicPermissionDefinitionStore { get; }
        protected IPermissionGrantRepository PermissionGrantRepository { get; }

        public DynamicPermissionStore(
            IDistributedCache<DynamicPermissionGrantCacheItem> cache,
            IDynamicPermissionDefinitionStore dynamicPermissionDefinitionStore,
            IPermissionGrantRepository permissionGrantRepository)
        {
            Cache = cache;
            DynamicPermissionDefinitionStore = dynamicPermissionDefinitionStore;
            PermissionGrantRepository = permissionGrantRepository;
        }
        
        public virtual async Task<bool> IsGrantedAsync(string name, string providerName, string providerKey)
        {
            return (await GetCacheItemAsync(name, providerName, providerKey)).IsGranted;
        }

        protected virtual async Task<DynamicPermissionGrantCacheItem> GetCacheItemAsync(string name, string providerName, string providerKey)
        {
            var cacheKey = CalculateCacheKey(name, providerName, providerKey);

            var cacheItem = await Cache.GetAsync(cacheKey);

            if (cacheItem != null)
            {
                return cacheItem;
            }

            cacheItem = new DynamicPermissionGrantCacheItem(false);

            await SetCacheItemsAsync(providerName, providerKey, name, cacheItem);

            return cacheItem;
        }
        
        protected virtual string CalculateCacheKey(string name, string providerName, string providerKey)
        {
            return DynamicPermissionGrantCacheItem.CalculateCacheKey(name, providerName, providerKey);
        }
        
        protected virtual async Task SetCacheItemsAsync(
            string providerName,
            string providerKey,
            string currentName,
            DynamicPermissionGrantCacheItem currentCacheItem)
        {
            var permissions = await DynamicPermissionDefinitionStore.GetDictionaryAsync();
            
            var grantedPermissionsHashSet = new HashSet<string>(
                (await PermissionGrantRepository.GetListAsync(providerName, providerKey)).Select(p => p.Name)
            );

            var cacheItems = new List<KeyValuePair<string, DynamicPermissionGrantCacheItem>>();

            foreach (var permission in permissions.Values)
            {
                var isGranted = grantedPermissionsHashSet.Contains(permission.Name);

                cacheItems.Add(new KeyValuePair<string, DynamicPermissionGrantCacheItem>(
                    CalculateCacheKey(permission.Name, providerName, providerKey),
                    new DynamicPermissionGrantCacheItem(isGranted))
                );

                if (permission.Name == currentName)
                {
                    currentCacheItem.IsGranted = isGranted;
                }
            }

            await Cache.SetManyAsync(cacheItems);
        }
    }
}