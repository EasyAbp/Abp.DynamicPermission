using System.Collections.Generic;
using System.Threading.Tasks;
using EasyAbp.Abp.DynamicPermission.Localization;
using EasyAbp.Abp.DynamicPermission.Permissions;
using Volo.Abp.UI.Navigation;

namespace EasyAbp.Abp.DynamicPermission.Blazor.Menus
{
    public class DynamicPermissionMenuContributor : IMenuContributor
    {
        public async Task ConfigureMenuAsync(MenuConfigurationContext context)
        {
            if (context.Menu.Name == StandardMenus.Main)
            {
                await ConfigureMainMenuAsync(context);
            }
        }

        private async Task ConfigureMainMenuAsync(MenuConfigurationContext context)
        {
            var l = context.GetLocalizer<DynamicPermissionResource>();
            
            var abpDynamicPermissionMenuItem = context.Menu.Items.GetOrAdd(
                i => i.Name == DynamicPermissionMenus.Prefix,
                () => new ApplicationMenuItem(DynamicPermissionMenus.Prefix, l["Menu:EasyAbpAbpDynamicPermission"])
            );
            
            if (await context.IsGrantedAsync(DynamicPermissionPermissions.PermissionDefinition.Default))
            {
                abpDynamicPermissionMenuItem.AddItem(
                    new ApplicationMenuItem(DynamicPermissionMenus.PermissionDefinition, l["Menu:PermissionDefinition"], "/Abp/DynamicPermission/PermissionDefinitions/PermissionDefinition")
                );
            }
        }
    }
}
