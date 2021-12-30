using System;
using EasyAbp.Abp.DynamicPermission.PermissionDefinitions.Dtos;
using Volo.Abp.Application.Dtos;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Volo.Abp;
using Volo.Abp.Application.Dtos;

namespace EasyAbp.Abp.DynamicPermission.PermissionDefinitions
{
    [RemoteService(Name = AbpDynamicPermissionRemoteServiceConsts.RemoteServiceName)]
    [Route("/api/abp/dynamic-permission/permission-definition")]
    public class PermissionDefinitionController : DynamicPermissionController, IPermissionDefinitionAppService
    {
        private readonly IPermissionDefinitionAppService _service;

        public PermissionDefinitionController(IPermissionDefinitionAppService service)
        {
            _service = service;
        }

        [HttpPost]
        [Route("")]
        public virtual Task<PermissionDefinitionDto> CreateAsync(CreateUpdatePermissionDefinitionDto input)
        {
            return _service.CreateAsync(input);
        }

        [HttpPut]
        [Route("{Name}")]
        public virtual Task<PermissionDefinitionDto> UpdateAsync(PermissionDefinitionKey id, CreateUpdatePermissionDefinitionDto input)
        {
            return _service.UpdateAsync(id, input);
        }

        [HttpDelete]
        [Route("{Name}")]
        public virtual Task DeleteAsync(PermissionDefinitionKey id)
        {
            return _service.DeleteAsync(id);
        }

        [HttpGet]
        [Route("{Name}")]
        public virtual Task<PermissionDefinitionDto> GetAsync(PermissionDefinitionKey id)
        {
            return _service.GetAsync(id);
        }

        [HttpGet]
        [Route("")]
        public virtual Task<PagedResultDto<PermissionDefinitionDto>> GetListAsync(PagedAndSortedResultRequestDto input)
        {
            return _service.GetListAsync(input);
        }
    }
}