using EasyAbp.Abp.DynamicPermission.Localization;
using Volo.Abp.Authorization.Permissions;
using Volo.Abp.Localization;

namespace EasyAbp.Abp.DynamicPermission.Permissions
{
    public class DynamicPermissionPermissionDefinitionProvider : PermissionDefinitionProvider
    {
        public override void Define(IPermissionDefinitionContext context)
        {
            var myGroup = context.AddGroup(DynamicPermissionPermissions.GroupName, L("Permission:DynamicPermission"));

            var permissionDefinitionPermission = myGroup.AddPermission(DynamicPermissionPermissions.PermissionDefinition.Default, L("Permission:PermissionDefinition"));
            permissionDefinitionPermission.AddChild(DynamicPermissionPermissions.PermissionDefinition.Create, L("Permission:Create"));
            permissionDefinitionPermission.AddChild(DynamicPermissionPermissions.PermissionDefinition.Update, L("Permission:Update"));
            permissionDefinitionPermission.AddChild(DynamicPermissionPermissions.PermissionDefinition.Delete, L("Permission:Delete"));
        }

        private static LocalizableString L(string name)
        {
            return LocalizableString.Create<DynamicPermissionResource>(name);
        }
    }
}
