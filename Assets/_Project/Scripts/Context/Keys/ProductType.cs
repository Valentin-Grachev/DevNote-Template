using System.Collections.Generic;

namespace DevNote
{
    public enum ProductKey
    {
        None = 0,
        NoAds = 1,
    }

    public static class ProductCatalog
    {
        private static readonly Dictionary<ProductKey, bool> isConsumableProducts = new Dictionary<ProductKey, bool>
        {
            { ProductKey.NoAds, false },
        };

        public static bool IsConsumable(ProductKey productKey) => isConsumableProducts[productKey];


    }


}



