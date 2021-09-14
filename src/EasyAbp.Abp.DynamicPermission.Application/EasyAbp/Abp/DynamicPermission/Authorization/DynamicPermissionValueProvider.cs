using System.Threading.Tasks;
using EasyAbp.Abp.DynamicPermission.PermissionGrants;
using Volo.Abp.DependencyInjection;

namespace EasyAbp.Abp.DynamicPermission.Authorization
{
    public abstract class DynamicPermissionValueProvider : IDynamicPermissionValueProvider, ITransientDependency
    {
        public abstract string Name { get; }
        
        protected IDynamicPermissionStore DynamicPermissionStore { get; }

        public DynamicPermissionValueProvider(IDynamicPermissionStore dynamicPermissionStore)
        {
            DynamicPermissionStore = dynamicPermissionStore;
        }
        
        public abstract Task<DynamicPermissionGrantResult> CheckAsync(DynamicPermissionValueCheckContext context);
    }
}