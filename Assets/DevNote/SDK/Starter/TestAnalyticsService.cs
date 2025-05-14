using System.Collections.Generic;
using UnityEngine;

namespace DevNote.Services.Starter
{
    public class TestAnalyticsService : MonoBehaviour, IAnalytics
    {
        public bool Initialized => true;

        bool ISelectableService.Available => true;

        public void Initialize() { }

        void IAnalytics.SendEvent(string eventKey, Dictionary<string, object> parameters)
        {
            string parametersDataString = string.Empty;

            if (parameters != null)
            {
                foreach (var parameter in parameters)
                    parametersDataString += $"({parameter.Key}: {parameter.Value}) ";
            }

            Debug.Log($"{Const.LOG_PREFIX} Send event \"{eventKey}\"; {parametersDataString}");
        }
    }
}


