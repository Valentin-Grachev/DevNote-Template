using System.Collections.Generic;
using UnityEngine;




namespace VG2
{


    public static class TimeQueue
    {
        public enum TimeType { Fast, PauseSlow, Pause, StopAll, GameSlow }



        private static Dictionary<TimeType, float> priorityTimeScales = new Dictionary<TimeType, float>
        {
            { TimeType.StopAll, 0f },
            { TimeType.Pause, 0f},
            { TimeType.PauseSlow, 0.3f },
            { TimeType.GameSlow, 0.5f },
            { TimeType.Fast, 2f }
        };

        private static List<TimeType> timeChanges = new List<TimeType>();



        public static void AddChange(TimeType timeType)
        {
            timeChanges.Add(timeType);
            UpdateTime();
               
        }

        public static void RemoveChange(TimeType timeType)
        {
            timeChanges.Remove(timeType);
            UpdateTime();
        }


        private static void UpdateTime()
        {
            AudioListener.volume = 1f;

            foreach (var priorityTimeScale in priorityTimeScales)
            {
                foreach (var timeChange in timeChanges)
                    if (priorityTimeScale.Key == timeChange)
                    {
                        Time.timeScale = priorityTimeScale.Value;

                        if (priorityTimeScale.Key == TimeType.StopAll)
                            AudioListener.volume = 0f;

                        return;
                    }


            }

            Time.timeScale = 1f;
        }








    }



}


