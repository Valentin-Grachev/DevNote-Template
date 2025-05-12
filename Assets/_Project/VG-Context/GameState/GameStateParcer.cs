using System;
using System.Collections.Generic;

namespace DevNote
{
    public static class GameStateParcer
    {
        private const string lastOnlineTimeKey = "lastOnlineTime";
        private const string adsEnabledKey = "adsEnabled";


        public static void Parse(Dictionary<string, string> data)
        {
            GameState.lastOnlineTime = data.ContainsKey(lastOnlineTimeKey) ?
                DateTime.Parse(data[lastOnlineTimeKey]) : DateTime.Now;

            GameState.adsEnabled = new ReactiveValue<bool>
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


