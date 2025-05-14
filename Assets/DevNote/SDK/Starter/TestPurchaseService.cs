using System;
using UnityEngine;

namespace DevNote.Services.Starter
{
    public class TestPurchaseService : MonoBehaviour, IPurchase
    {
        bool IInitializable.Initialized => true;

        bool ISelectableService.Available => true;

        string IPurchase.GetPriceString(ProductKey productKey) => $"${productKey}";

        void IInitializable.Initialize() { }

        void IPurchase.Purchase(ProductKey productKey, Action onSuccess, Action onError)
        {
            PurchaseHandler.HandlePurchase(productKey);
            onSuccess?.Invoke();
        }
    }
}



