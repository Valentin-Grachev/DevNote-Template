using System.Collections.Generic;
using VG2.Internal;

namespace VG2
{
    public abstract class AnalyticsService : Service
    {

        public abstract void SendEvent(string eventKey, Dictionary<string, object> parameters);

    }
}



