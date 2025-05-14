using UnityEngine;

namespace DevNote
{
    public static class PurchaseHandler
    {
        public static void HandlePurchase(ProductType key)
        {
            
            switch (key)
            {
                case ProductType.NoAds:
                    GameState.adsEnabled.Value = false;
                    break;

                default: 
                    Debug.LogWarning($"Handle for product {key} does'nt exist!");
                    break;
            }
            
            
        }


    }
}

