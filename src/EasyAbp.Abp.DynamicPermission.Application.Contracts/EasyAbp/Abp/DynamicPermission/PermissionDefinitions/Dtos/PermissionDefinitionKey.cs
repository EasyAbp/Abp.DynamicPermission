using System;
using JetBrains.Annotations;

namespace EasyAbp.Abp.DynamicPermission.PermissionDefinitions.Dtos
{
    public class PermissionDefinitionKey
    {
        public string Name { get; set; }

        public PermissionDefinitionKey()
        {
        }
        
        public PermissionDefinitionKey([NotNull] string name)
        {
            Name = name;
        }
    }
}