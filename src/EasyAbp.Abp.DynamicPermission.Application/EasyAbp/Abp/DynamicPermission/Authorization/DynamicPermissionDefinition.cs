using Volo.Abp.Authorization.Permissions;
using Volo.Abp.Localization;
using Volo.Abp.MultiTenancy;

namespace EasyAbp.Abp.DynamicPermission.Authorization
{
    public class DynamicPermissionDefinition : PermissionDefinition
    {
        protected internal DynamicPermissionDefinition(string name, ILocalizableString displayName = null,
            MultiTenancySides multiTenancySide = MultiTenancySides.Both) : base(name, displayName, multiTenancySide)
        {
        }
    }
}