using System.Collections.Generic;
using UnityEngine;

namespace DevNote
{
    [System.Serializable]
    public class ProductIdConvertor
    {
        [System.Serializable]
        private struct ProductTypeId
        {
            public ProductType type;
            public string id;
        }

        [SerializeField] private List<ProductTypeId> _productIds;

        public string GetProductId(ProductType productType)
            => _productIds.Find((typeId) => typeId.type == productType).id;

        public ProductType GetProductType(string productId)
            => _productIds.Find((typeId) => typeId.id == productId).type;



    }
}


