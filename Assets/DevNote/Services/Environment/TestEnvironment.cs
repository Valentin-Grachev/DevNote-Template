using UnityEngine;
using VG2;


namespace DevNote
{
    public class TestEnvironment : MonoBehaviour, IEnvironment, ISelectableService
    {
        [SerializeField] private bool _isTest = false;
        [SerializeField] private Language _currentLanguage = Language.EN;
        [SerializeField] private ControlType _controlType = ControlType.Desktop;


        bool ISelectableService.Available => true;

        bool IEnvironment.IsTest => _isTest;

        Language IEnvironment.CurrentLanguage => _currentLanguage;

        ControlType IEnvironment.ControlType => _controlType;

        void IEnvironment.GameReady() => Debug.Log($"{Const.LogPrefix} Game ready");
    }
}


