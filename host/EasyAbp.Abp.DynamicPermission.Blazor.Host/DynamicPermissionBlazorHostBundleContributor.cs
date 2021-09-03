using Volo.Abp.Bundling;

namespace EasyAbp.Abp.DynamicPermission.Blazor.Host
{
    public class DynamicPermissionBlazorHostBundleContributor : IBundleContributor
    {
        public void AddScripts(BundleContext context)
        {

        }

        public void AddStyles(BundleContext context)
        {
            context.Add("main.css", true);
        }
    }
}
