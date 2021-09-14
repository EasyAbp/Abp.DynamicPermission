using System;
using EasyAbp.Abp.DynamicPermission.PermissionDefinitions;
using EasyAbp.Abp.DynamicPermission.PermissionGrants;
using Microsoft.Extensions.Caching.Distributed;
using Volo.Abp.Caching;
using Volo.Abp.Domain;
using Volo.Abp.Modularity;

namespace EasyAbp.Abp.DynamicPermission
{
    [DependsOn(
        typeof(AbpCachingModule),
        typeof(AbpDddDomainModule),
        typeof(AbpDynamicPermissionDomainSharedModule)
    )]
    public class AbpDynamicPermissionDomainModule : AbpModule
    {
        public override void PreConfigureServices(ServiceConfigurationContext context)
        {
            Configure<AbpDistributedCacheOptions>(options =>
            {
                options.CacheConfigurators.Add(cacheName =>
                {
                    if (cacheName == CacheNameAttribute.GetCacheName(typeof(DynamicPermissionGrantCacheItem)))
                    {
                        return new DistributedCacheEntryOptions()
                        {
                            AbsoluteExpirationRelativeToNow = TimeSpan.FromSeconds(60)
                        };
                    }

                    return null;
                });
                
                options.CacheConfigurators.Add(cacheName =>
                {
                    if (cacheName == CacheNameAttribute.GetCacheName(typeof(DynamicPermissionDefinitionCacheItem)))
                    {
                        return new DistributedCacheEntryOptions()
                        {
                            AbsoluteExpirationRelativeToNow = TimeSpan.FromSeconds(3600)
                        };
                    }

                    return null;
                });
            });
        }
    }
}
