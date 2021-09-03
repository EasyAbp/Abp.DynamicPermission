using System;
using JetBrains.Annotations;
using Volo.Abp;
using Volo.Abp.Domain.Entities;
using Volo.Abp.MultiTenancy;

namespace EasyAbp.Abp.DynamicPermission.PermissionGrants
{
    public class PermissionGrant : AggregateRoot<Guid>, IMultiTenant
    {
        public virtual Guid? TenantId { get; protected set; }

        [NotNull]
        public virtual string Name { get; protected set; }

        [NotNull]
        public virtual string ProviderName { get; protected set; }

        [CanBeNull]
        public virtual string ProviderKey { get; protected internal set; }

        protected PermissionGrant()
        {
        }

        public PermissionGrant(
            Guid id,
            Guid? tenantId,
            [NotNull] string name,
            [NotNull] string providerName,
            [CanBeNull] string providerKey
        ) : base(id)
        {
            TenantId = tenantId;

            Update(name, providerName, providerKey);
        }

        public void Update(
            string name,
            string providerName,
            string providerKey)
        {
            Name = Check.NotNullOrWhiteSpace(name, nameof(name));
            ProviderName = Check.NotNullOrWhiteSpace(providerName, nameof(providerName));
            ProviderKey = providerKey;
        }
    }
}
