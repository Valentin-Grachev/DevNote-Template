using Cysharp.Threading.Tasks;
using DevNote.YandexGamesSDK;
using UnityEngine;

namespace DevNote.Services.YandexGames
{
    public class YandexGamesEnvironmentService : MonoBehaviour, IEnvironment
    {
        [SerializeField] private YG_Sdk _yandexGamesSdkPrefab;

        private bool _initialized = false;
        private Language _definedLanguage;

        bool ISelectableService.Available => YG_Sdk.ServicesIsSupported;

        bool IInitializable.Initialized => _initialized;
        async void IInitializable.Initialize()
        {
            Instantiate(_yandexGamesSdkPrefab, parent: null);

            await UniTask.WaitUntil(() => YG_Sdk.available);

            _definedLanguage = YG_Sdk.GetLanguage() switch
            {
                "ru" => Language.RU,
                "en" => Language.EN,
                "tr" => Language.TR,
                _ => Language.EN
            };

            _initialized = true;
        }


        Language IEnvironment.CurrentLanguage => _definedLanguage;

        ControlType IEnvironment.ControlType => YG_Sdk.GetDeviceType();

        void IEnvironment.GameReady() => YG_GameReady.GameReady();


        
    }

}

