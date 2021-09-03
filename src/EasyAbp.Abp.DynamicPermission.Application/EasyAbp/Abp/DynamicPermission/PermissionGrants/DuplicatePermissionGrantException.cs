using JetBrains.Annotations;
using Volo.Abp;

namespace EasyAbp.Abp.DynamicPermission.PermissionGrants
{
    public class DuplicatePermissionGrantException : UserFriendlyException
    {
        public DuplicatePermissionGrantException([NotNull] string name, [NotNull] string providerName,
            [CanBeNull] string providerKey) : base(
            $"Duplicate permission grant: [Name] {name}, [ProviderName] {providerName}, [ProviderKey] {providerKey}",
            "DuplicatePermissionGrant")
        {
        }
    }
}