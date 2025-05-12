using VG2;

namespace DevNote
{
    public static class PurchasesHandler
    {
        public static void HandlePurchase(ProductType productKey)
        {
            
            switch (productKey)
            {
                case ProductType.NoAds:
                    GameState.adsEnabled.Value = false;
                    break;

                default: throw new System.Exception("Wrong product: " + productKey.ToString());
            }
            
            
        }


    }
}

