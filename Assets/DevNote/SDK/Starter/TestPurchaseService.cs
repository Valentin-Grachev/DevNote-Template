using System;
using UnityEngine;

namespace DevNote.Services.Starter
{
    public class TestPurchaseService : MonoBehaviour, IPurchase
    {
        public event IPurchase.OnPurchaseHandled onPurchaseHandled;


        bool IInitializable.Initialized => true;

        bool ISelectableService.Available => true;

        

        string IPurchase.GetPriceString(ProductType productType) => $"${productType}";

        void IInitializable.Initialize() { }

        void IPurchase.Purchase(ProductType productType, Action onSuccess, Action onError)
        {
            PurchaseHandler.HandlePurchase(productType);
            onPurchaseHandled?.Invoke(productType, true);
            onSuccess?.Invoke();
        }
    }
}



