using DevNote;
using UnityEngine;
using UnityEngine.Events;


namespace VG2
{
    public class LocalizedSprite : ReactiveView
    {
        [SerializeField] private string _key;
        [SerializeField] private UnityEvent<Sprite> _onUpdate;

        protected override void Subscribe()
        {
            Localization.onLanguageChanged += Display;
        }

        protected override void Dispose()
        {
            Localization.onLanguageChanged -= Display;
        }


        protected override void Display() => _onUpdate?.Invoke(Localization.GetSprite(_key));
    }
}


