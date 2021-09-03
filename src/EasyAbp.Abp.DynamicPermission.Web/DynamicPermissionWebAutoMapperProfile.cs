using EasyAbp.Abp.DynamicPermission.PermissionDefinitions.Dtos;
using EasyAbp.Abp.DynamicPermission.Web.Pages.Abp.DynamicPermission.PermissionDefinitions.PermissionDefinition.ViewModels;
using EasyAbp.Abp.DynamicPermission.PermissionGrants.Dtos;
using EasyAbp.Abp.DynamicPermission.Web.Pages.Abp.DynamicPermission.PermissionGrants.PermissionGrant.ViewModels;
using AutoMapper;

namespace EasyAbp.Abp.DynamicPermission.Web
{
    public class DynamicPermissionWebAutoMapperProfile : Profile
    {
        public DynamicPermissionWebAutoMapperProfile()
        {
            /* You can configure your AutoMapper mapping configuration here.
             * Alternatively, you can split your mapping configurations
             * into multiple profile classes for a better organization. */
            CreateMap<PermissionDefinitionDto, CreateEditPermissionDefinitionViewModel>();
            CreateMap<CreateEditPermissionDefinitionViewModel, CreateUpdatePermissionDefinitionDto>();
            CreateMap<PermissionGrantDto, CreateEditPermissionGrantViewModel>();
            CreateMap<CreateEditPermissionGrantViewModel, CreateUpdatePermissionGrantDto>();
        }
    }
}
