using NaughtyAttributes;
using TMPro;
using UnityEngine;


namespace VG2
{
    public class PurchasePrice : MonoBehaviour
    {
        [SerializeField] private bool _useConstantKey = true;
        [ShowIf(nameof(_useConstantKey))]
        [SerializeField] private ProductType _productKey = ProductType.None;


        private void Start()
        {
            GetComponent<TextMeshProUGUI>().text = Purchases.GetPriceString(_productKey);
        }

        public void SetProduct(ProductType productKey)
        {
            if (_useConstantKey)
                Debug.LogWarning("[Purchase Price] Setting product key for constant key!");

            _productKey = productKey;
            GetComponent<TextMeshProUGUI>().text = Purchases.GetPriceString(productKey);
        }

    }
}



