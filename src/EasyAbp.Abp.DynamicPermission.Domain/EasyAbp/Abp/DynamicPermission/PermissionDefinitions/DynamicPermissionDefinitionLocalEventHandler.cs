using System.Threading.Tasks;
using Volo.Abp.Caching;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Domain.Entities.Events;
using Volo.Abp.EventBus;
using Volo.Abp.Uow;

namespace EasyAbp.Abp.DynamicPermission.PermissionDefinitions
{
    public class DynamicPermissionDefinitionLocalEventHandler : ILocalEventHandler<EntityChangedEventData<PermissionDefinition>>, ITransientDependency
    {
        private readonly IUnitOfWorkManager _unitOfWorkManager;
        private readonly IDistributedCache<DynamicPermissionDefinitionCacheItem> _cache;

        public DynamicPermissionDefinitionLocalEventHandler(
            IUnitOfWorkManager unitOfWorkManager,
            IDistributedCache<DynamicPermissionDefinitionCacheItem> cache)
        {
            _unitOfWorkManager = unitOfWorkManager;
            _cache = cache;
        }
        
        public virtual Task HandleEventAsync(EntityChangedEventData<PermissionDefinition> eventData)
        {
            _unitOfWorkManager.Current?.OnCompleted(async () =>
            {
                await _cache.RemoveAsync(DynamicPermissionDefinitionStore.CacheKey);
            });
            
            return Task.CompletedTask;
        }
    }
}