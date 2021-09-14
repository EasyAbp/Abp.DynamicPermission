using System.Threading.Tasks;
using Volo.Abp.Caching;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Domain.Entities.Events;
using Volo.Abp.EventBus;

namespace EasyAbp.Abp.DynamicPermission.PermissionDefinitions
{
    public class DynamicPermissionDefinitionLocalEventHandler : ILocalEventHandler<EntityChangedEventData<PermissionDefinition>>, ITransientDependency
    {
        private readonly IDistributedCache<DynamicPermissionDefinitionCacheItem> _cache;

        public DynamicPermissionDefinitionLocalEventHandler(
            IDistributedCache<DynamicPermissionDefinitionCacheItem> cache)
        {
            _cache = cache;
        }
        
        public virtual async Task HandleEventAsync(EntityChangedEventData<PermissionDefinition> eventData)
        {
            await _cache.RemoveAsync(DynamicPermissionDefinitionStore.CacheKey);
        }
    }
}