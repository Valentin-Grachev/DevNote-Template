using System.Collections.Generic;

namespace VG2
{
    public enum ProductType
    {
        None = 0,
        NoAds = 1,
    }

    public static class Products
    {
        public static ProductType GetProductTypeByKey(string key)
        {
            foreach (var info in Infos)
                if (info.Value.key == key) return info.Key;

            return ProductType.None;
        }


        public static readonly Dictionary<ProductType, ProductInfo> Infos = new Dictionary<ProductType, ProductInfo>
        {
            {
                ProductType.NoAds,
                new ProductInfo { type = ProductType.NoAds, key = "no_ads", isConsumable = false }
            },

        };
            
    }


}
