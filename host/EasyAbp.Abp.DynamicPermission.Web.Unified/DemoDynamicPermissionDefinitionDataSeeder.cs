using System.Threading.Tasks;
using EasyAbp.Abp.DynamicPermission.PermissionDefinitions;
using Volo.Abp.Data;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Uow;

namespace EasyAbp.Abp.DynamicPermission
{
    public class DemoDynamicPermissionDefinitionDataSeeder : IDataSeeder, ITransientDependency
    {
        protected const string PermissionDefinitionDemo1Name = "Permission1";
        protected const string PermissionDefinitionDemo2Name = "Permission2";
        
        private readonly IPermissionDefinitionRepository _permissionDefinitionRepository;

        public DemoDynamicPermissionDefinitionDataSeeder(
            IPermissionDefinitionRepository permissionDefinitionRepository)
        {
            _permissionDefinitionRepository = permissionDefinitionRepository;
        }
        
        [UnitOfWork]
        public async Task SeedAsync(DataSeedContext context)
        {
            if (!await _permissionDefinitionRepository.AnyAsync(x => x.Name == PermissionDefinitionDemo1Name))
            {
                await _permissionDefinitionRepository.InsertAsync(
                    new PermissionDefinition(PermissionDefinitionDemo1Name, PermissionDefinitionDemo1Name, "A demo",
                        true), true);
            }
            
            if (!await _permissionDefinitionRepository.AnyAsync(x => x.Name == PermissionDefinitionDemo2Name))
            {
                await _permissionDefinitionRepository.InsertAsync(
                    new PermissionDefinition(PermissionDefinitionDemo2Name, PermissionDefinitionDemo2Name, "A demo",
                        false), true);
            }
        }
    }
}