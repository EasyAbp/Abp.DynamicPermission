using System;
using System.ComponentModel;
namespace EasyAbp.Abp.DynamicPermission.PermissionDefinitions.Dtos
{
    [Serializable]
    public class CreateUpdatePermissionDefinitionDto
    {
        public string Name { get; set; }

        public string DisplayName { get; set; }

        public string Description { get; set; }

        public bool IsPublic { get; set; }
    }
}