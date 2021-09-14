using System;
using System.Collections.Generic;
using System.Linq;
using Volo.Abp.Text.Formatting;

namespace EasyAbp.Abp.DynamicPermission.PermissionDefinitions
{
    [Serializable]
    public class DynamicPermissionDefinitionCacheItem
    {
        public Dictionary<string, PermissionDefinition> PermissionDefinitions { get; set; }

        public DynamicPermissionDefinitionCacheItem(Dictionary<string, PermissionDefinition> permissionDefinitions)
        {
            PermissionDefinitions = permissionDefinitions;
        }
    }
}