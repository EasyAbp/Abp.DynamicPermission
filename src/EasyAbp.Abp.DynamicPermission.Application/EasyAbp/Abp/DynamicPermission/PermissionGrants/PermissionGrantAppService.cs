using System;
using System.Threading.Tasks;
using EasyAbp.Abp.DynamicPermission.Permissions;
using EasyAbp.Abp.DynamicPermission.PermissionGrants.Dtos;
using JetBrains.Annotations;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace EasyAbp.Abp.DynamicPermission.PermissionGrants
{
    public class PermissionGrantAppService : CrudAppService<PermissionGrant, PermissionGrantDto, Guid, PagedAndSortedResultRequestDto, CreateUpdatePermissionGrantDto, CreateUpdatePermissionGrantDto>,
        IPermissionGrantAppService
    {
        protected override string GetPolicyName { get; set; } = DynamicPermissionPermissions.PermissionGrant.Default;
        protected override string GetListPolicyName { get; set; } = DynamicPermissionPermissions.PermissionGrant.Default;
        protected override string CreatePolicyName { get; set; } = DynamicPermissionPermissions.PermissionGrant.Manage;
        protected override string UpdatePolicyName { get; set; } = DynamicPermissionPermissions.PermissionGrant.Manage;
        protected override string DeletePolicyName { get; set; } = DynamicPermissionPermissions.PermissionGrant.Manage;

        private readonly IPermissionGrantRepository _repository;
        
        public PermissionGrantAppService(IPermissionGrantRepository repository) : base(repository)
        {
            _repository = repository;
        }

        public override async Task<PermissionGrantDto> CreateAsync(CreateUpdatePermissionGrantDto input)
        {
            await CheckDuplicateAsync(input.Name, input.ProviderName, input.ProviderKey);

            var grant = new PermissionGrant(GuidGenerator.Create(), CurrentTenant.Id, input.Name, input.ProviderName,
                input.ProviderKey);

            await _repository.InsertAsync(grant, true);
            
            return await MapToGetOutputDtoAsync(grant);
        }

        public override async Task<PermissionGrantDto> UpdateAsync(Guid id, CreateUpdatePermissionGrantDto input)
        {
            var grant = await GetEntityByIdAsync(id);

            await CheckDuplicateAsync(input.Name, input.ProviderName, input.ProviderKey, grant.Id);

            grant.Update(input.Name, input.ProviderName, input.ProviderKey);

            await _repository.UpdateAsync(grant, true);

            return await MapToGetOutputDtoAsync(grant);
        }

        protected virtual async Task CheckDuplicateAsync([NotNull] string name, [NotNull] string providerName,
            [CanBeNull] string providerKey, Guid? exceptId = null)
        {
            var duplicateGrant = await _repository.FindAsync(name, providerName, providerKey);

            if (duplicateGrant != null && duplicateGrant.Id != exceptId)
            {
                throw new DuplicatePermissionGrantException(name, providerName, providerKey);
            }
        }
    }
}
