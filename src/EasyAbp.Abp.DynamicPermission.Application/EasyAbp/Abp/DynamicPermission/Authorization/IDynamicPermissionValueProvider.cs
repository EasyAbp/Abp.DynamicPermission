using System.Threading.Tasks;

namespace EasyAbp.Abp.DynamicPermission.Authorization
{
    public interface IDynamicPermissionValueProvider
    {
        string Name { get; }

        Task<DynamicPermissionGrantResult> CheckAsync(DynamicPermissionValueCheckContext context);
    }
}