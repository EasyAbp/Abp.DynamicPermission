using System.Threading.Tasks;
using EasyAbp.Abp.DynamicPermission.PermissionDefinitions;
using Volo.Abp.Data;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Guids;
using Volo.Abp.MultiTenancy;

namespace EasyAbp.Abp.DynamicPermission
{
    public class DynamicPermissionDataSeedContributor : IDataSeedContributor, ITransientDependency
    {
        private readonly IPermissionDefinitionRepository _permissionDefinitionRepository;
        private readonly IGuidGenerator _guidGenerator;
        private readonly ICurrentTenant _currentTenant;

        public DynamicPermissionDataSeedContributor(
            IPermissionDefinitionRepository permissionDefinitionRepository,
            IGuidGenerator guidGenerator,
            ICurrentTenant currentTenant)
        {
            _permissionDefinitionRepository = permissionDefinitionRepository;
            _guidGenerator = guidGenerator;
            _currentTenant = currentTenant;
        }

        public async Task SeedAsync(DataSeedContext context)
        {
            /* Instead of returning the Task.CompletedTask, you can insert your test data
             * at this point!
             */

            using (_currentTenant.Change(context?.TenantId))
            {
                await _permissionDefinitionRepository.InsertAsync(new PermissionDefinition(
                    DynamicPermissionTestConsts.Permission1Name, "Test permission 1", "A permission for test.", true), true);
                
                await _permissionDefinitionRepository.InsertAsync(new PermissionDefinition(
                    DynamicPermissionTestConsts.Permission2Name, "Test permission 2", "A permission for test.", true), true);
            }
        }
    }
}
