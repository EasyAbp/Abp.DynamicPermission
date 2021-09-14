using System;
using System.Linq;
using Volo.Abp.Text.Formatting;

namespace EasyAbp.Abp.DynamicPermission.PermissionGrants
{
    [Serializable]
    public class DynamicPermissionGrantCacheItem
    {
        private const string CacheKeyFormat = "pn:{0},pk:{1},n:{2}";

        public bool IsGranted { get; set; }

        public DynamicPermissionGrantCacheItem()
        {

        }

        public DynamicPermissionGrantCacheItem(bool isGranted)
        {
            IsGranted = isGranted;
        }

        public static string CalculateCacheKey(string name, string providerName, string providerKey)
        {
            return string.Format(CacheKeyFormat, providerName, providerKey, name);
        }

        public static string GetPermissionNameFormCacheKeyOrNull(string cacheKey)
        {
            var result = FormattedStringValueExtracter.Extract(cacheKey, CacheKeyFormat, true);
            return result.IsMatch ? result.Matches.Last().Value : null;
        }
    }
}