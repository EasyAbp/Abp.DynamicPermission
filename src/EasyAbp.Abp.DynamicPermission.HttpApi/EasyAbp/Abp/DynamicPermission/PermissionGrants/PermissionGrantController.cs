using System;
using EasyAbp.Abp.DynamicPermission.PermissionGrants.Dtos;
using Volo.Abp.Application.Dtos;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Volo.Abp;
using Volo.Abp.Application.Dtos;

namespace EasyAbp.Abp.DynamicPermission.PermissionGrants
{
    [RemoteService(Name = "DynamicPermissionPermissionGrant")]
    [Route("/api/abp/dynamic-permission/permission-grant")]
    public class PermissionGrantController : DynamicPermissionController, IPermissionGrantAppService
    {
        private readonly IPermissionGrantAppService _service;

        public PermissionGrantController(IPermissionGrantAppService service)
        {
            _service = service;
        }

        [HttpPost]
        [Route("")]
        public virtual Task<PermissionGrantDto> CreateAsync(CreateUpdatePermissionGrantDto input)
        {
            return _service.CreateAsync(input);
        }

        [HttpPut]
        [Route("{id}")]
        public virtual Task<PermissionGrantDto> UpdateAsync(Guid id, CreateUpdatePermissionGrantDto input)
        {
            return _service.UpdateAsync(id, input);
        }

        [HttpDelete]
        [Route("{id}")]
        public virtual Task DeleteAsync(Guid id)
        {
            return _service.DeleteAsync(id);
        }

        [HttpGet]
        [Route("{id}")]
        public virtual Task<PermissionGrantDto> GetAsync(Guid id)
        {
            return _service.GetAsync(id);
        }

        [HttpGet]
        [Route("")]
        public virtual Task<PagedResultDto<PermissionGrantDto>> GetListAsync(PagedAndSortedResultRequestDto input)
        {
            return _service.GetListAsync(input);
        }
    }
}