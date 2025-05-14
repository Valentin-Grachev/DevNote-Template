using System;

namespace DevNote
{
    public interface IPurchase : IInitializable, ISelectableService
    {
        public string GetPriceString(ProductKey productKey);
        public void Purchase(ProductKey productKey, Action onSuccess = null, Action onError = null);
    }

}
