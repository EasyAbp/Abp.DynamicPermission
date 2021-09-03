using System;
using Volo.Abp.Application.Dtos;

namespace EasyAbp.Abp.DynamicPermission.PermissionGrants.Dtos
{
    [Serializable]
    public class PermissionGrantDto : EntityDto<Guid>
    {
        public string Name { get; set; }

        public string ProviderName { get; set; }

        public string ProviderKey { get; set; }
    }
}