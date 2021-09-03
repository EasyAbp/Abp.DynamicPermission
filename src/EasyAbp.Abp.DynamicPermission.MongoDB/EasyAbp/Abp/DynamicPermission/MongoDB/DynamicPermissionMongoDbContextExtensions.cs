using System;
using Volo.Abp;
using Volo.Abp.MongoDB;

namespace EasyAbp.Abp.DynamicPermission.MongoDB
{
    public static class DynamicPermissionMongoDbContextExtensions
    {
        public static void ConfigureDynamicPermission(
            this IMongoModelBuilder builder,
            Action<AbpMongoModelBuilderConfigurationOptions> optionsAction = null)
        {
            Check.NotNull(builder, nameof(builder));

            var options = new DynamicPermissionMongoModelBuilderConfigurationOptions(
                DynamicPermissionDbProperties.DbTablePrefix
            );

            optionsAction?.Invoke(options);
        }
    }
}