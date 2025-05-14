using UnityEngine;

namespace DevNote
{
    public static class PurchaseHandler
    {
        public static void HandlePurchase(ProductType productType)
        {
            
            switch (productType)
            {
                case ProductType.NoAds:
                    GameState.adsEnabled.Value = false;
                    break;

                default: 
                    Debug.LogWarning($"Handle for product {productType} does'nt exist!");
                    break;
            }
            
            
        }


    }
}

