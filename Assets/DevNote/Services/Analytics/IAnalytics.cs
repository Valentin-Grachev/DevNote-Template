using System.Collections.Generic;

namespace DevNote
{
    public interface IAnalytics : IInitializable, ISelectableService
    {
        
        public void SendEvent(EventKey eventKey, Dictionary<string, object> parameters = null);


    }

}
