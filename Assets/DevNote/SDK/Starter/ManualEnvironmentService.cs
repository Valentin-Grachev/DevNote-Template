using System;
using UnityEngine;


namespace DevNote.Services.Starter
{
    public class ManualEnvironmentService : MonoBehaviour, IEnvironment
    {
        [SerializeField] private Language _currentLanguage = Language.EN;
        [SerializeField] private DeviceType _deviceType = DeviceType.Desktop;


        bool IInitializable.Initialized => true;

        void IInitializable.Initialize() { }

        bool ISelectableService.Available => true;

        Language IEnvironment.CurrentLanguage => _currentLanguage;

        DeviceType IEnvironment.DeviceType => _deviceType;

        DateTime IEnvironment.ServerTime => DateTime.Now;

        void IEnvironment.GameReady() => Debug.Log($"{Const.LOG_PREFIX} Game ready");

        
    }
}


