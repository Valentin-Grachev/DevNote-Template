using System;
using System.Collections.Generic;
using Cysharp.Threading.Tasks;
using UnityEngine;


namespace DevNote
{

    public class Localization : MonoBehaviour, IInitializable
    {
        public static event Action onLanguageChanged;
        public static Language CurrentLanguage { get; private set; }

        private static Localization _instance;


        [SerializeField] private GoogleTables _googleTables;

        private Dictionary<string, Translation> _tranlationDictionary = new();
        private LocalizationConfig _config;

        private bool _initialized = false;


        public bool Initialized => _initialized;
        async void IInitializable.Initialize()
        {
            _instance = this;
            _config = Resources.Load<LocalizationConfig>("Localization");

            await UniTask.WaitUntil(() => (_googleTables as IInitializable).Initialized);

            foreach (var translation in _config.Translations)
                _tranlationDictionary.Add(translation.key, translation);

            _initialized = true;
        }


        public static void SetLanguage(Language language)
        {
            CurrentLanguage = _instance._config.AvailableLanguages.Contains(language) ?
                language : _instance._config.DefaultLanguage;

            onLanguageChanged?.Invoke();
        }

        public static string GetLocalizedText(string key)
        {
            if (_instance._tranlationDictionary.ContainsKey(key) == false)
            {
                Debug.LogWarning($"{Const.LOG_PREFIX} Translation key \"{key}\" does'nt exist!");
                return key;
            }

            string localizedString = _instance._tranlationDictionary[key].GetTranslation(CurrentLanguage);
            return localizedString.Replace("\r", "");
        }


    }


}


