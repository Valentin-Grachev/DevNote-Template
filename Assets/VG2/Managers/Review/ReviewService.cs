using System;
using VG2.Internal;


namespace VG2
{
    public abstract class ReviewService : Service
    {
        public abstract void Request(Action onOpened, Action onClosed);

    }
}

