using System.Collections.Generic;
using UnityEngine;

namespace DevNote
{
    public class TestAnalyticsService : MonoBehaviour, IAnalytics, ISelectableService
    {
        bool ISelectableService.Available => true;

        void IAnalytics.SendEvent(EventKey eventKey, Dictionary<string, object> parameters)
        {
            string parametersDataString = string.Empty;

            if (parameters != null)
            {
                foreach (var parameter in parameters)
                    parametersDataString += $"{parameter.Key}: {parameter.Value}";
            }

            Debug.Log($"{Const.LogPrefix} Send event: {eventKey} {parametersDataString}");
        }
    }
}


