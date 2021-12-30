using System;
using System.Linq;
using System.Threading.Tasks;
using EasyAbp.Abp.DynamicPermission.Permissions;
using EasyAbp.Abp.DynamicPermission.PermissionDefinitions.Dtos;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace EasyAbp.Abp.DynamicPermission.PermissionDefinitions
{
    public class PermissionDefinitionAppService : AbstractKeyCrudAppService<PermissionDefinition, PermissionDefinitionDto, PermissionDefinitionKey, PagedAndSortedResultRequestDto, CreateUpdatePermissionDefinitionDto, CreateUpdatePermissionDefinitionDto>,
        IPermissionDefinitionAppService
    {
        protected override string GetPolicyName { get; set; } = DynamicPermissionPermissions.PermissionDefinition.Default;
        protected override string GetListPolicyName { get; set; } = DynamicPermissionPermissions.PermissionDefinition.Default;
        protected override string CreatePolicyName { get; set; } = DynamicPermissionPermissions.PermissionDefinition.Create;
        protected override string UpdatePolicyName { get; set; } = DynamicPermissionPermissions.PermissionDefinition.Update;
        protected override string DeletePolicyName { get; set; } = DynamicPermissionPermissions.PermissionDefinition.Delete;

        private readonly IPermissionDefinitionRepository _repository;
        
        public PermissionDefinitionAppService(IPermissionDefinitionRepository repository) : base(repository)
        {
            _repository = repository;
        }
        
        protected override Task DeleteByIdAsync(PermissionDefinitionKey id)
        {
            // TODO: AbpHelper generated
            return _repository.DeleteAsync(e =>
                e.Name == id.Name
            );
        }

        protected override async Task<PermissionDefinition> GetEntityByIdAsync(PermissionDefinitionKey id)
        {
            // TODO: AbpHelper generated
            return await AsyncExecuter.FirstOrDefaultAsync(
                (await _repository.GetQueryableAsync()).Where(e =>
                    e.Name == id.Name
                )
            ); 
        }

        protected override IQueryable<PermissionDefinition> ApplyDefaultSorting(IQueryable<PermissionDefinition> query)
        {
            // TODO: AbpHelper generated
            return query.OrderBy(e => e.Name);
        }
    }
}
