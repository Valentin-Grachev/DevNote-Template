using VG2;

namespace DevNote
{
    public interface IEnvironment
    {
        public static PlatformType PlatformType
        {
            get
            {
                #if UNITY_WEBGL
                    return PlatformType.WebGL;
                #endif

                #if UNITY_ANDROID
                    return PlatformType.Android;
                #endif

                #if UNITY_STANDALONE
                    return PlatformType.Desktop;
                #endif

                #if UNITY_IOS
                    return PlatformType.iOS;
                #endif
            }
        }

        public static bool IsEditor
        {
            get
            {
                #if UNITY_EDITOR
                    return true;
                #else
                    return false;
                #endif
            }
        }

        public bool IsTest { get; }
        public Language CurrentLanguage { get; }
        public ControlType ControlType { get; }
        public void GameReady();

    }

}

