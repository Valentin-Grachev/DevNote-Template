using TMPro;
using UnityEngine;


namespace DevNote
{
    [RequireComponent(typeof(TextMeshProUGUI))]
    public class LocalizedText : MonoBehaviour
    {
        [SerializeField] private string _key;

        private TextMeshProUGUI _text;

        private void OnEnable()
        {
            Localization.OnLanguageChanged += Display;
            Display();
        }

        private void OnDisable()
        {
            Localization.OnLanguageChanged -= Display;
        }


        private void Display()
        {
            if (_key == string.Empty)
            {
                Debug.LogWarning($"{Const.LOG_PREFIX} Localized text: ID is empty!");
                return;
            }

            if (_text == null) 
                _text = GetComponent<TextMeshProUGUI>();

            _text.text = Localization.GetLocalizedText(_key);
        }

        public void SetKey(string key)
        {
            _key = key;
            Display();
        }
        
    }
}



