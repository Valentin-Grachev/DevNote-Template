using UnityEngine;
using UnityEngine.Events;
using R3;


namespace VG2
{
    public class LocalizedSprite : ReactiveView
    {
        [SerializeField] private string _key;
        [SerializeField] private UnityEvent<Sprite> _onUpdate;

        protected override void Subscribe()
        {
            disposables.Add(Localization.onLanguageChanged.Subscribe(_ => Display()));
        }


        protected override void Display() => _onUpdate?.Invoke(Localization.GetSprite(_key));
    }
}


