using EasyAbp.Abp.DynamicPermission.PermissionDefinitions.Dtos;
using EasyAbp.Abp.DynamicPermission.Web.Pages.Abp.DynamicPermission.PermissionDefinitions.PermissionDefinition.ViewModels;
using Riok.Mapperly.Abstractions;
using Volo.Abp.Mapperly;

namespace EasyAbp.Abp.DynamicPermission.Web
{
    [Mapper(RequiredMappingStrategy = RequiredMappingStrategy.Target)]
    public partial class PermissionDefinitionDtoToCreateEditPermissionDefinitionViewModelMapper : MapperBase<PermissionDefinitionDto, CreateEditPermissionDefinitionViewModel>
    {
        public override partial CreateEditPermissionDefinitionViewModel Map(PermissionDefinitionDto source);

        public override partial void Map(PermissionDefinitionDto source, CreateEditPermissionDefinitionViewModel destination);
    }

    [Mapper(RequiredMappingStrategy = RequiredMappingStrategy.Target)]
    public partial class CreateEditPermissionDefinitionViewModelToCreateUpdatePermissionDefinitionDtoMapper : MapperBase<CreateEditPermissionDefinitionViewModel, CreateUpdatePermissionDefinitionDto>
    {
        public override partial CreateUpdatePermissionDefinitionDto Map(CreateEditPermissionDefinitionViewModel source);

        public override partial void Map(CreateEditPermissionDefinitionViewModel source, CreateUpdatePermissionDefinitionDto destination);
    }
}
