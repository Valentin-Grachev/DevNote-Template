using UnityEngine;
using UnityEngine.Events;

namespace VG2.Internal
{
    public class DefinedLanguage_BootStatus : MonoBehaviour
    {
        [SerializeField] private UnityEvent<string> _onLanguageDefined;


        public void SetLanguage(Language language)
        {
            _onLanguageDefined?.Invoke("Language: " + language.ToString());
        }



    }
}



