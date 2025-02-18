using NaughtyAttributes;
using UnityEngine;


namespace VG2
{

    public class PurchaseButton : ButtonHandler
    {
        [SerializeField] private bool _useConstantKey = true;
        [ShowIf(nameof(_useConstantKey))]
        [SerializeField] private ProductType _productKey = ProductType.None;

        protected override void OnClick() => Purchases.Purchase(_productKey);

        public void SetProduct(ProductType productKey)
        {
            if (_useConstantKey) 
                Debug.LogWarning("[Purchase Button] Setting product key for constant key!");

            _productKey = productKey;
        }

    }
}



