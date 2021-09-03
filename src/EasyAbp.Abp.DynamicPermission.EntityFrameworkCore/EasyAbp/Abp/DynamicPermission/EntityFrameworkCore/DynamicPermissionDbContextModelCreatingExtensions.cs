using EasyAbp.Abp.DynamicPermission.PermissionGrants;
using EasyAbp.Abp.DynamicPermission.PermissionDefinitions;
using System;
using Microsoft.EntityFrameworkCore;
using Volo.Abp;
using Volo.Abp.EntityFrameworkCore.Modeling;

namespace EasyAbp.Abp.DynamicPermission.EntityFrameworkCore
{
    public static class DynamicPermissionDbContextModelCreatingExtensions
    {
        public static void ConfigureAbpDynamicPermission(
            this ModelBuilder builder,
            Action<DynamicPermissionModelBuilderConfigurationOptions> optionsAction = null)
        {
            Check.NotNull(builder, nameof(builder));

            var options = new DynamicPermissionModelBuilderConfigurationOptions(
                DynamicPermissionDbProperties.DbTablePrefix,
                DynamicPermissionDbProperties.DbSchema
            );

            optionsAction?.Invoke(options);

            /* Configure all entities here. Example:

            builder.Entity<Question>(b =>
            {
                //Configure table & schema name
                b.ToTable(options.TablePrefix + "Questions", options.Schema);
            
                b.ConfigureByConvention();
            
                //Properties
                b.Property(q => q.Title).IsRequired().HasMaxLength(QuestionConsts.MaxTitleLength);
                
                //Relations
                b.HasMany(question => question.Tags).WithOne().HasForeignKey(qt => qt.QuestionId);

                //Indexes
                b.HasIndex(q => q.CreationTime);
            });
            */


            builder.Entity<PermissionDefinition>(b =>
            {
                b.ToTable(options.TablePrefix + "PermissionDefinitions", options.Schema);
                b.ConfigureByConvention(); 
                
                b.HasKey(e => new
                {
                    e.Name,
                });

                /* Configure more properties here */
            });


            builder.Entity<PermissionGrant>(b =>
            {
                b.ToTable(options.TablePrefix + "PermissionGrants", options.Schema);
                b.ConfigureByConvention(); 
                
                b.HasIndex(x => new {x.Name, x.ProviderName, x.ProviderKey});

                /* Configure more properties here */
            });
        }
    }
}
