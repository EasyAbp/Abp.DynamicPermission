using Volo.Abp.Data;
using Volo.Abp.MongoDB;

namespace EasyAbp.Abp.DynamicPermission.MongoDB
{
    [ConnectionStringName(DynamicPermissionDbProperties.ConnectionStringName)]
    public interface IDynamicPermissionMongoDbContext : IAbpMongoDbContext
    {
        /* Define mongo collections here. Example:
         * IMongoCollection<Question> Questions { get; }
         */
    }
}
