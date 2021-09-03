using System;
using EasyAbp.Abp.DynamicPermission.PermissionDefinitions.Dtos;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace EasyAbp.Abp.DynamicPermission.PermissionDefinitions
{
    public interface IPermissionDefinitionAppService :
        ICrudAppService< 
            PermissionDefinitionDto, 
            PermissionDefinitionKey, 
            PagedAndSortedResultRequestDto,
            CreateUpdatePermissionDefinitionDto,
            CreateUpdatePermissionDefinitionDto>
    {

    }
}