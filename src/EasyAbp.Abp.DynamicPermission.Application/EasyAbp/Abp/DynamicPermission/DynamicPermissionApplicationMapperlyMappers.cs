using EasyAbp.Abp.DynamicPermission.PermissionDefinitions;
using EasyAbp.Abp.DynamicPermission.PermissionDefinitions.Dtos;
using Riok.Mapperly.Abstractions;
using Volo.Abp.Mapperly;

namespace EasyAbp.Abp.DynamicPermission
{
    [Mapper(RequiredMappingStrategy = RequiredMappingStrategy.Target)]
    public partial class PermissionDefinitionToPermissionDefinitionDtoMapper : MapperBase<PermissionDefinition, PermissionDefinitionDto>
    {
        public override partial PermissionDefinitionDto Map(PermissionDefinition source);

        public override partial void Map(PermissionDefinition source, PermissionDefinitionDto destination);
    }
}
