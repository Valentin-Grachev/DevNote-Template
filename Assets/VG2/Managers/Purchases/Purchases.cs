using System;
using System.Collections;
using UnityEngine;
using VG2.Internal;


namespace VG2
{
    public class Purchases : Manager
    {
        public delegate void OnPurchased(ProductType productKey, bool success);
        public static event OnPurchased onPurchased;

        private static Purchases instance;

        private static PurchaseService service => instance.supportedService as PurchaseService;
        protected override string managerName => "VG IAP";

        public override void Initialize()
        {
            StartCoroutine(InitializeWithSaves());
        }

        private IEnumerator InitializeWithSaves()
        {
            yield return new WaitUntil(() => Saves.Initialized);

            supportedService = GetSupportedService();
            supportedService.onInitialized += InitCompleted;
            supportedService.Initialize();
            
        }

        protected override void OnInitialized()
        {
            instance = this;
            Log(Core.Message.Initialized(managerName));
        }

        public static string GetPriceString(ProductType productType) 
            => service.GetPriceString(Products.Infos[productType].key);




        public static void Purchase(ProductType productType, Action<bool> onSuccess = null)
        {
            var productKey = Products.Infos[productType].key;
            instance.Log("Product purchase processing, key:" + productKey);

            service.Purchase(productKey, (success) =>
            {
                if (success)
                {
                    instance.Log("On purchased: " + productKey);
                    PurchasesHandler.HandlePurchase(productType);
                    Saves.Save();
                }
                else instance.Log("On not purchased: " + productKey);

                onSuccess?.Invoke(success);
                onPurchased?.Invoke(productType, success);
            });
        }


    }

}
