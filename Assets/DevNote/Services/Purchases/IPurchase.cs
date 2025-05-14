using System;

namespace DevNote
{
    public interface IPurchase : IInitializable, ISelectableService
    {
        public delegate void OnPurchaseHandled(bool success);
        public event OnPurchaseHandled onPurchaseHandled;


        public string GetPriceString(ProductType productType);
        public void Purchase(ProductType productType, Action onSuccess = null, Action onError = null);
    }

}
