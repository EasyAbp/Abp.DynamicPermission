using System;
using EasyAbp.Abp.DynamicPermission.PermissionGrants.Dtos;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace EasyAbp.Abp.DynamicPermission.PermissionGrants
{
    public interface IPermissionGrantAppService :
        ICrudAppService< 
            PermissionGrantDto, 
            Guid, 
            PagedAndSortedResultRequestDto,
            CreateUpdatePermissionGrantDto,
            CreateUpdatePermissionGrantDto>
    {

    }
}