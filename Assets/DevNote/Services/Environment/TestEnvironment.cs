using UnityEngine;
using VG2;


namespace DevNote
{
    public class TestEnvironment : MonoBehaviour, IEnvironment
    {
        [SerializeField] private Language _currentLanguage = Language.EN;
        [SerializeField] private ControlType _controlType = ControlType.Desktop;


        bool IInitializable.Initialized => true;

        void IInitializable.Initialize() { }

        bool ISelectableService.Available => true;

        Language IEnvironment.CurrentLanguage => _currentLanguage;

        ControlType IEnvironment.ControlType => _controlType;

        

        void IEnvironment.GameReady() => Debug.Log($"{Const.LogPrefix} Game ready");

        
    }
}


