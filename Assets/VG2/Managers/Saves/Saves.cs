using System;
using VG2.Internal;

namespace VG2
{
    public partial class Saves : Manager
    {
        public static event Action onDeleted;
        public static bool Initialized { get; private set; }
        private static SaveService service => _instance.supportedService as SaveService;

        private static Saves _instance;

        private static bool _savesDeleted = false;

        protected override string managerName => "VG Saves";


        protected override void OnInitialized()
        {
            _instance = this;

            var dataDictionary = GameStateEncoder.Decode(service.GetData(), _instance._debugLogs);
            GameStateParcer.Parse(dataDictionary);

            Initialized = true;
        }

        public static void Save(bool isImportant = false)
        {
            if (_savesDeleted) return;

            var gameStateData = GameStateParcer.ToDataString();
            var encodedData = GameStateEncoder.Encode(gameStateData);

            service.SaveLocal(encodedData);
        }

        public static void Delete()
        {
            _instance.Log("Delete.");
            service.SaveLocal(string.Empty);

            _savesDeleted = true;
            onDeleted?.Invoke();
        }
        

    }


}




