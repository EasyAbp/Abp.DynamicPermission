namespace EasyAbp.Abp.DynamicPermission
{
    public static class DynamicPermissionDbProperties
    {
        public static string DbTablePrefix { get; set; } = "EasyAbpAbpDynamicPermission";

        public static string DbSchema { get; set; } = null;

        public const string ConnectionStringName = "EasyAbpAbpDynamicPermission";
    }
}
