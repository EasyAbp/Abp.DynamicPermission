using Volo.Abp.Data;
using Volo.Abp.MongoDB;

namespace EasyAbp.Abp.DynamicPermission.MongoDB
{
    [ConnectionStringName(DynamicPermissionDbProperties.ConnectionStringName)]
    public class DynamicPermissionMongoDbContext : AbpMongoDbContext, IDynamicPermissionMongoDbContext
    {
        /* Add mongo collections here. Example:
         * public IMongoCollection<Question> Questions => Collection<Question>();
         */

        protected override void CreateModel(IMongoModelBuilder modelBuilder)
        {
            base.CreateModel(modelBuilder);

            modelBuilder.ConfigureDynamicPermission();
        }
    }
}