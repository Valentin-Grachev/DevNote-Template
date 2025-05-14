using System;
using Cysharp.Threading.Tasks;
using DevNote.YandexGamesSDK;
using UnityEngine;

namespace DevNote.Services.YandexGames
{
    public class YandexGamesSaveService : MonoBehaviour, ISave
    {
        private bool _initialized = false;

        private const string LOCAL_DATA_KEY = "data";


        bool ISelectableService.Available => YG_Sdk.ServicesIsSupported;

        bool IInitializable.Initialized => _initialized;

        async void IInitializable.Initialize()
        {
            await UniTask.WaitUntil(() => YG_Saves.available);
            YG_Saves.InitializePlayer();

            YG_Saves.RequestSaves((savedData) =>
            {
                var dataDictionary = GameStateEncoder.Decode(savedData);
                GameStateParcer.Parse(dataDictionary);

                _initialized = true;
            });

        }


        void ISave.SaveLocal(Action onSuccess, Action onError)
        {
            var gameStateData = GameStateParcer.ToDataString();
            var encodedData = GameStateEncoder.Encode(gameStateData);
            PlayerPrefs.SetString(LOCAL_DATA_KEY, encodedData);
            PlayerPrefs.Save();
            onSuccess?.Invoke();
        }

        void ISave.SaveCloud(Action onSuccess, Action onError)
        {
            var gameStateData = GameStateParcer.ToDataString();
            var encodedData = GameStateEncoder.Encode(gameStateData);

            YG_Saves.SendSaves(encodedData, onSavesSent: (success) =>
            {
                if (success) onSuccess?.Invoke();
                else onError?.Invoke();
            });
        }

        void ISave.DeleteSaves(Action onSuccess, Action onError)
        {
            YG_Saves.SendSaves(string.Empty, onSavesSent: (success) =>
            {
                if (success) onSuccess?.Invoke();
                else onError?.Invoke();
            });
        }

        
    }
}


