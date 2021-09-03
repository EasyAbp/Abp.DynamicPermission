using System;
using Volo.Abp.Application.Dtos;

namespace EasyAbp.Abp.DynamicPermission.PermissionDefinitions.Dtos
{
    [Serializable]
    public class PermissionDefinitionDto : AuditedEntityDto
    {
        public string Name { get; set; }

        public string DisplayName { get; set; }

        public string Description { get; set; }

        public bool IsPublic { get; set; }
    }
}