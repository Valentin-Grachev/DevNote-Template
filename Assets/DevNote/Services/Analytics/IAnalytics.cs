using System.Collections.Generic;

namespace DevNote
{
    public interface IAnalytics : IProjectInitializable, ISelectableService
    {
        
        public void SendEvent(string eventName, Dictionary<string, object> parameters = null);


    }

}
