using System;
using System.Collections;
using System.Collections.Generic;
using DevNote.YandexGamesSDK;
using UnityEngine;


namespace DevNote.Services.YandexGames
{
    public class YandexGamesPurchaseService : MonoBehaviour, IPurchase
    {


        private List<string> _purchasedProductIds;
        private Dictionary<string, string> _productPrices;


        bool ISelectableService.Available => YG_Sdk.ServicesIsSupported;
        bool IInitializable.Initialized => throw new NotImplementedException();

        void IInitializable.Initialize()
        {
            throw new NotImplementedException();
        }


        string IPurchase.GetPriceString(ProductKey productKey)
        {
            if (!_productPrices.ContainsKey(productKey.ToString()))
                return string.Empty;

            return _productPrices[productKey.ToString()];
        }

        void IPurchase.Purchase(ProductKey productKey, Action onSuccess, Action onError)
        {
            onSuccess += (success) =>
            {
                if (success) YG_Purchases.Consume(productKey);
            };
            YG_Purchases.Purchase(productKey, onSuccess);
        }

        



        public override string GetPriceString(string productKey)
        {
            
        }




        public override void Initialize()
        {
            Saves.onDeleted += OnSavesDeleted;
            StartCoroutine(PurchasesInitializing());
        }

        

        private IEnumerator PurchasesInitializing()
        {
            yield return new WaitUntil(() => YG_Purchases.available);

#if UNITY_WEBGL
                YG_Purchases.InitializePayments();
#endif

            YG_Purchases.GetPurchasedProducts((purchasedProductIds) =>
            {
                _purchasedProductIds = purchasedProductIds;
                foreach (var purchasedProductKey in _purchasedProductIds)
                {
                    if (purchasedProductKey == string.Empty) continue;

                    var productType = Products.GetProductTypeByKey(purchasedProductKey);

                    PurchasesHandler.HandlePurchase(productType);
                    if (Products.Infos[productType].isConsumable)
                        YG_Purchases.Consume(purchasedProductKey);
                }
            });

            YG_Purchases.GetPrices((productPrices) => _productPrices = productPrices);

            yield return new WaitUntil(
                () => _purchasedProductIds != null && _productPrices != null);

            InitCompleted();
        }

        public override void Purchase(string productKey, Action<bool> onSuccess)
        {
            
        }


        private void OnSavesDeleted()
        {
            YG_Purchases.GetPurchasedProducts((purchasedProductIds) =>
            {
                foreach (var purchasedProductKey in purchasedProductIds)
                    YG_Purchases.Consume(purchasedProductKey);
            });
        }

        
    }
}


