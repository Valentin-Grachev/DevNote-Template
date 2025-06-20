using System.Collections.Generic;

namespace DevNote
{
    public static class GameStateParcer
    {
        private const string ADS_ENABLED_KEY = "adsEnabled";


        public static void Parse(Dictionary<string, string> data)
        {
            GameState.AdsEnabled = new ReactiveValue<bool>
                (data.ContainsKey(ADS_ENABLED_KEY) ? bool.Parse(data[ADS_ENABLED_KEY]) : true);

        }


        public static Dictionary<string, string> ToDataString()
        {
            var data = new Dictionary<string, string>();

            data.Add(ADS_ENABLED_KEY, GameState.AdsEnabled.Value.ToString());

            return data;
        }


    }
}


