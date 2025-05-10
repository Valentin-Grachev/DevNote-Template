using System.Collections.Generic;

namespace DevNote
{
    public interface IAnalytics
    {
        
        public void SendEvent(EventKey eventKey, Dictionary<string, object> parameters = null);


    }

}
