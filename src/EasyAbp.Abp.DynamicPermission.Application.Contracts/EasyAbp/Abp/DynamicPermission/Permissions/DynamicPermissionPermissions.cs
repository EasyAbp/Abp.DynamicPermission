using Volo.Abp.Reflection;

namespace EasyAbp.Abp.DynamicPermission.Permissions
{
    public class DynamicPermissionPermissions
    {
        public const string GroupName = "EasyAbp.Abp.DynamicPermission";

        public static string[] GetAll()
        {
            return ReflectionHelper.GetPublicConstantsRecursively(typeof(DynamicPermissionPermissions));
        }

        public class PermissionDefinition
        {
            public const string Default = GroupName + ".PermissionDefinition";
            public const string Update = Default + ".Update";
            public const string Create = Default + ".Create";
            public const string Delete = Default + ".Delete";
        }
    }
}
