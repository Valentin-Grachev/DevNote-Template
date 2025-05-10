using DevNote.Utils;
using UnityEngine;

namespace VG2
{
    public class Autosave : MonoBehaviour
    {
        private const float LOCAL_SAVE_COOLDOWN = 1f;
        private const float CLOUD_SAVE_COOLDOWN = 60f;

        private float _timeToLocalSave = LOCAL_SAVE_COOLDOWN;
        private float _timeToCloudSave = CLOUD_SAVE_COOLDOWN;

        private void Awake()
        {
            WebHandler.onPageBeforeUnload += () => Saves.Save();
            WebHandler.onPageHidden += () => Saves.Save();
        }

        private void Update()
        {
            if (!Startup.Loaded) return;


            _timeToLocalSave -= Time.unscaledDeltaTime;
            _timeToCloudSave -= Time.unscaledDeltaTime;

            if (_timeToLocalSave < 0f)
            {
                _timeToLocalSave = LOCAL_SAVE_COOLDOWN;
                Saves.Save();
            }

            if (_timeToCloudSave < 0f)
            {
                _timeToCloudSave = CLOUD_SAVE_COOLDOWN;
                Saves.Save(isImportant: true);
            }
        }


        private void OnApplicationFocus(bool focus)
        {
            if (!Startup.Loaded) return;

            if (!focus) Saves.Save();
        }

        private void OnApplicationPause(bool pause)
        {
            if (!Startup.Loaded) return;

            if (pause) Saves.Save();
        }

        private void OnApplicationQuit()
        {
            if (!Startup.Loaded) return;

            Saves.Save();
        }




    }
}



