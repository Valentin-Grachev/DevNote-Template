using System;
using VG2.Internal;

namespace VG2
{
    public abstract class PurchaseService : Service
    {
        public abstract string GetPriceString(string productKey);
        public abstract void Purchase(string productKey, Action<bool> onSuccess);

    }
}



