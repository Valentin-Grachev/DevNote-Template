using System;
using Cysharp.Threading.Tasks;
using UnityEngine;


namespace DevNote
{
    public class PlayerPrefsSaveService : MonoBehaviour, ISave
    {
        private bool _initialized = false;

        private const string DATA_KEY = "data";


        bool ISelectableService.Available => true;

        bool IInitializable.Initialized => _initialized;

        async void IInitializable.Initialize()
        {
            var dataDictionary = GameStateEncoder.Decode(PlayerPrefs.GetString(DATA_KEY, string.Empty));
            GameStateParcer.Parse(dataDictionary);

            await UniTask.WaitForSeconds(3);


            _initialized = true;
        }


        void ISave.DeleteSaves(Action onSuccess, Action onError)
        {
            PlayerPrefs.SetString(DATA_KEY, string.Empty);
            PlayerPrefs.Save();
            onSuccess?.Invoke();
        }

        void ISave.SaveCloud(Action onSuccess, Action onError) => Save(onSuccess);

        void ISave.SaveLocal(Action onSuccess, Action onError) => Save(onSuccess);

        private void Save(Action onSuccess)
        {
            var gameStateData = GameStateParcer.ToDataString();
            var encodedData = GameStateEncoder.Encode(gameStateData);
            PlayerPrefs.SetString(DATA_KEY, encodedData);
            PlayerPrefs.Save();
            onSuccess?.Invoke();
        }

    }
}


