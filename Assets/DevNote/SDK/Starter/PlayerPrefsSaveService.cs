using System;
using NaughtyAttributes;
using UnityEngine;


namespace DevNote.Services.Starter
{
    public class PlayerPrefsSaveService : MonoBehaviour, ISave
    {
        public event Action onSavesDeleted;

        private bool _initialized = false;

        private const string DATA_KEY = "data";

        

        bool ISelectableService.Available => true;

        bool IProjectInitializable.Initialized => _initialized;

        void IProjectInitializable.Initialize()
        {
            var encodedData = PlayerPrefs.GetString(DATA_KEY, string.Empty);
            GameState.RestoreFromEncodedData(encodedData);

            _initialized = true;
        }


        void ISave.DeleteSaves(Action onSuccess, Action onError)
        {
            PlayerPrefs.SetString(DATA_KEY, string.Empty);
            PlayerPrefs.Save();

            onSuccess?.Invoke();
            onSavesDeleted?.Invoke();
        }

        void ISave.SaveCloud(Action onSuccess, Action onError) => Save(onSuccess);

        void ISave.SaveLocal(Action onSuccess, Action onError) => Save(onSuccess);

        private void Save(Action onSuccess)
        {
            PlayerPrefs.SetString(DATA_KEY, GameState.GetEncodedData());
            PlayerPrefs.Save();

            onSuccess?.Invoke();
        }



        [Button("Clear Player Prefs")]
        private void ClearData() => PlayerPrefs.DeleteAll();





    }
}


