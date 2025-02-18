using System;
using System.Runtime.InteropServices;
using UnityEngine;



namespace VG2.YandexGames
{
    public class YG_Sdk : MonoBehaviour
    {
        private static bool _sdkInitialized = false;
        public static bool available 
        { 
            get 
            {
#if UNITY_WEBGL
                CheckSdkInit();
#endif
                return _sdkInitialized;
            } 
        }

        private void HTML_OnSdkInitChecked(int initialized) => _sdkInitialized = Convert.ToBoolean(initialized);


        public static string GetLanguage()
        {
#if UNITY_WEBGL
            RequestLanguage();
#endif
            return _receivedLanguage;
        }

        private static string _receivedLanguage;
        private void HTML_OnLanguageReceived(string language) => _receivedLanguage = language;


        private static ControlType _receivedDeviceType;
        private void HTML_OnDeviceTypeReceived(string deviceType)
        {
            if (deviceType == "desktop") _receivedDeviceType = ControlType.Desktop;
            else _receivedDeviceType = ControlType.Mobile;
        }
        public static ControlType GetDeviceType()
        {
#if UNITY_WEBGL
            _GetDeviceType();
#endif
            return _receivedDeviceType;
        }




#if UNITY_WEBGL
        [DllImport("__Internal")] private static extern string RequestLanguage();
        [DllImport("__Internal")] private static extern void CheckSdkInit();
        [DllImport("__Internal")] private static extern void _GetDeviceType();
#endif

    }
}



