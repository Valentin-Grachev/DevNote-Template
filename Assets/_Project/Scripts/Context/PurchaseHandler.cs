using UnityEngine;

namespace DevNote
{
    public static class PurchaseHandler
    {
        public static void HandlePurchase(ProductKey key)
        {
            
            switch (key)
            {
                case ProductKey.NoAds:
                    GameState.adsEnabled.Value = false;
                    break;

                default: 
                    Debug.LogWarning($"Handle for product {key} does'nt exist!");
                    break;
            }
            
            
        }


    }
}

