using JetBrains.Annotations;
using Volo.Abp.Domain.Entities.Auditing;

namespace EasyAbp.Abp.DynamicPermission.PermissionDefinitions
{
    public class PermissionDefinition : AuditedAggregateRoot
    {
        [NotNull]
        public virtual string Name { get; protected set; }

        [NotNull]
        public virtual string DisplayName { get; protected set; }
        
        [CanBeNull]
        public virtual string Description { get; protected set; }
        
        public virtual bool IsPublic { get; protected set; }

        public override object[] GetKeys()
        {
            return new object[] { Name };
        }

        protected PermissionDefinition()
        {
        }

        public PermissionDefinition(
            string name,
            string displayName,
            string description,
            bool isPublic
        )
        {
            Name = name;
            DisplayName = displayName;
            Description = description;
            IsPublic = isPublic;
        }
    }
}
