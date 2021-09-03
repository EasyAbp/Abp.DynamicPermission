using EasyAbp.Abp.DynamicPermission.PermissionDefinitions;
using EasyAbp.Abp.DynamicPermission.PermissionDefinitions.Dtos;
using EasyAbp.Abp.DynamicPermission.PermissionGrants;
using EasyAbp.Abp.DynamicPermission.PermissionGrants.Dtos;
using AutoMapper;

namespace EasyAbp.Abp.DynamicPermission
{
    public class DynamicPermissionApplicationAutoMapperProfile : Profile
    {
        public DynamicPermissionApplicationAutoMapperProfile()
        {
            /* You can configure your AutoMapper mapping configuration here.
             * Alternatively, you can split your mapping configurations
             * into multiple profile classes for a better organization. */
            CreateMap<PermissionDefinition, PermissionDefinitionDto>();
            CreateMap<CreateUpdatePermissionDefinitionDto, PermissionDefinition>(MemberList.Source);
            CreateMap<PermissionGrant, PermissionGrantDto>();
            CreateMap<CreateUpdatePermissionGrantDto, PermissionGrant>(MemberList.Source);
        }
    }
}
