using System;
using System.ComponentModel;
namespace EasyAbp.Abp.DynamicPermission.PermissionGrants.Dtos
{
    [Serializable]
    public class CreateUpdatePermissionGrantDto
    {
        public string Name { get; set; }

        public string ProviderName { get; set; }

        public string ProviderKey { get; set; }
    }
}