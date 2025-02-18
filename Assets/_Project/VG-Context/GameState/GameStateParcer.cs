using System;
using System.Collections.Generic;
using R3;

namespace VG2
{
    public static class GameStateParcer
    {
        private const string lastOnlineTimeKey = "lastOnlineTime";
        private const string adsEnabledKey = "adsEnabled";


        public static void Parse(StartValuesConfig startValuesConfig, Dictionary<string, string> data)
        {
            GameState.lastOnlineTime = data.ContainsKey(lastOnlineTimeKey) ?
                DateTime.Parse(data[lastOnlineTimeKey]) : DateTime.Now;

            GameState.adsEnabled = new ReactiveProperty<bool>
                (data.ContainsKey(adsEnabledKey) ? bool.Parse(data[adsEnabledKey]) : true);

        }


        public static Dictionary<string, string> ToDataString()
        {
            var data = new Dictionary<string, string>();

            data.Add(lastOnlineTimeKey, GameState.lastOnlineTime.ToString());
            data.Add(adsEnabledKey, GameState.adsEnabled.ToString());

            return data;
        }


    }
}


