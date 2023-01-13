using System.Linq;
using System.Threading.Tasks;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Domain.Entities.Events;
using Volo.Abp.EventBus;
using Volo.Abp.Guids;
using Volo.Abp.PermissionManagement;
using Volo.Abp.Uow;

namespace EasyAbp.Abp.DynamicPermission.PermissionDefinitions
{
    public class DynamicPermissionDefinitionLocalEventHandler :
        ILocalEventHandler<EntityCreatedEventData<PermissionDefinition>>,
        ILocalEventHandler<EntityUpdatedEventData<PermissionDefinition>>,
        ILocalEventHandler<EntityDeletedEventData<PermissionDefinition>>,
        IUnitOfWorkEnabled,
        ITransientDependency
    {
        public static string DynamicPermissionGroupName = "DynamicPermission";

        private readonly IGuidGenerator _guidGenerator;
        private readonly IPermissionGroupDefinitionRecordRepository _permissionGroupDefinitionRecordRepository;
        private readonly IPermissionDefinitionRecordRepository _permissionDefinitionRecordRepository;
        private readonly IDynamicPermissionDefinitionStoreInMemoryCache _storeCache;

        public DynamicPermissionDefinitionLocalEventHandler(
            IGuidGenerator guidGenerator,
            IPermissionGroupDefinitionRecordRepository permissionGroupDefinitionRecordRepository,
            IPermissionDefinitionRecordRepository permissionDefinitionRecordRepository,
            IDynamicPermissionDefinitionStoreInMemoryCache storeCache)
        {
            _guidGenerator = guidGenerator;
            _permissionGroupDefinitionRecordRepository = permissionGroupDefinitionRecordRepository;
            _permissionDefinitionRecordRepository = permissionDefinitionRecordRepository;
            _storeCache = storeCache;
        }

        public virtual async Task HandleEventAsync(EntityCreatedEventData<PermissionDefinition> eventData)
        {
            await TryCreateGroupAsync();

            var record = await _permissionDefinitionRecordRepository.FindByNameAsync(eventData.Entity.Name);

            if (record != null)
            {
                return;
            }

            await _permissionDefinitionRecordRepository.InsertAsync(new PermissionDefinitionRecord(
                _guidGenerator.Create(), DynamicPermissionGroupName, eventData.Entity.Name, null,
                eventData.Entity.DisplayName), true);

            await ClearStoreCacheAsync();
        }

        public virtual async Task HandleEventAsync(EntityUpdatedEventData<PermissionDefinition> eventData)
        {
            await TryCreateGroupAsync();

            var record = await _permissionDefinitionRecordRepository.FindByNameAsync(eventData.Entity.Name);

            if (record == null || record.GroupName != DynamicPermissionGroupName)
            {
                return;
            }

            record.DisplayName = eventData.Entity.DisplayName;

            await _permissionDefinitionRecordRepository.UpdateAsync(record, true);

            await ClearStoreCacheAsync();
        }

        public virtual async Task HandleEventAsync(EntityDeletedEventData<PermissionDefinition> eventData)
        {
            await TryCreateGroupAsync();

            var record = await _permissionDefinitionRecordRepository.FindByNameAsync(eventData.Entity.Name);

            if (record == null || record.GroupName != DynamicPermissionGroupName)
            {
                return;
            }

            await _permissionDefinitionRecordRepository.DeleteAsync(record, true);

            await ClearStoreCacheAsync();
        }

        protected virtual async Task TryCreateGroupAsync()
        {
            var permissionGroupRecords = (await _permissionGroupDefinitionRecordRepository.GetListAsync())
                .ToDictionary(x => x.Name);

            if (permissionGroupRecords.ContainsKey(DynamicPermissionGroupName))
            {
                return;
            }

            await _permissionGroupDefinitionRecordRepository.InsertAsync(
                new PermissionGroupDefinitionRecord(_guidGenerator.Create(), DynamicPermissionGroupName,
                    DynamicPermissionGroupName), true);
        }

        protected virtual Task ClearStoreCacheAsync()
        {
            _storeCache.LastCheckTime = null;
            _storeCache.CacheStamp = null;

            return Task.CompletedTask;
        }
    }
}