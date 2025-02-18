using TMPro;
using UnityEngine;
using R3;


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
            disposables.Add(Localization.onLanguageChanged.Subscribe(_ => Display()));
            if (_useToken)
                disposables.Add(Localization.onTokenChanged.Subscribe(_ => Display()));
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
            Display();
        }


        private void OnValidate()
        {
            if (TryGetComponent<TextMeshProUGUI>(out var text)) text.text = $"<{_key}>";
        }




    }
}



