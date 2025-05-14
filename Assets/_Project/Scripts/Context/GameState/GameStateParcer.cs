using System.Collections.Generic;

namespace DevNote
{
    public static class GameStateParcer
    {
        private const string adsEnabledKey = "adsEnabled";


        public static void Parse(Dictionary<string, string> data)
        {
            GameState.adsEnabled = new ReactiveValue<bool>
                (data.ContainsKey(adsEnabledKey) ? bool.Parse(data[adsEnabledKey]) : true);

        }


        public static Dictionary<string, string> ToDataString()
        {
            var data = new Dictionary<string, string>();

            data.Add(adsEnabledKey, GameState.adsEnabled.Value.ToString());

            return data;
        }


    }
}


