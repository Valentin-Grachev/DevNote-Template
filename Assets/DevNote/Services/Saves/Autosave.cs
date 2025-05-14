using UnityEngine;
using Zenject;

namespace DevNote
{
    public class Autosave : MonoBehaviour
    {
        [Inject] private readonly ISave save;


        private const float LOCAL_SAVE_COOLDOWN = 1f;
        private const float CLOUD_SAVE_COOLDOWN = 60f;

        private float _timeToLocalSave = LOCAL_SAVE_COOLDOWN;
        private float _timeToCloudSave = CLOUD_SAVE_COOLDOWN;

        private void Awake()
        {
            WebHandler.onPageBeforeUnload += () => save.SaveLocal();
            WebHandler.onPageHidden += () => save.SaveLocal();
        }

        private void Update()
        {
            if (!save.Initialized) return;

            _timeToLocalSave -= Time.unscaledDeltaTime;
            _timeToCloudSave -= Time.unscaledDeltaTime;

            if (_timeToLocalSave < 0f)
            {
                _timeToLocalSave = LOCAL_SAVE_COOLDOWN;
                save.SaveLocal();
            }

            if (_timeToCloudSave < 0f)
            {
                _timeToCloudSave = CLOUD_SAVE_COOLDOWN;
                save.SaveCloud();
            }
        }


        private void OnApplicationFocus(bool focus)
        {
            if (!save.Initialized) return;

            if (!focus) save.SaveLocal();
        }

        private void OnApplicationPause(bool pause)
        {
            if (!save.Initialized) return;

            if (pause) save.SaveLocal();
        }

        private void OnApplicationQuit()
        {
            if (!save.Initialized) return;

            save.SaveCloud();
        }




    }
}



