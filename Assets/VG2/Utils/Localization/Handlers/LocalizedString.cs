using DevNote;
using TMPro;
using UnityEngine;


namespace VG2
{
    [RequireComponent(typeof(TextMeshProUGUI))]
    public class LocalizedString : ReactiveView
    {
        [SerializeField] private string _key;
        [SerializeField] private bool _useToken;

        private TextMeshProUGUI _text;

        protected override void Subscribe()
        {
            Localization.onLanguageChanged += Display;
            if (_useToken) Localization.onTokenChanged += Display;
        }

        protected override void Dispose()
        {
            Localization.onLanguageChanged -= Display;
            if (_useToken) Localization.onTokenChanged -= Display;
        }

        protected override void Display()
        {
            if (_key == string.Empty) return;

            _text ??= GetComponent<TextMeshProUGUI>();
            _text.text = Localization.GetString(_key, _useToken);
        }
        


        public void SetKey(string key, bool useToken)
        {
            _key = key;
            _useToken = useToken;

            Dispose();
            Subscribe();

            Display();
        }


        private void OnValidate()
        {
            if (TryGetComponent<TextMeshProUGUI>(out var text)) text.text = $"<{_key}>";
        }

        
    }
}



