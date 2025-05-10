using System;
using UnityEngine;


namespace DevNote
{
    public class PlayerPrefsSaveService : MonoBehaviour, ISave, ISelectableService
    {

        bool ISelectableService.Available => true;

        void ISave.DeleteSaves(Action onSuccess, Action onError)
        {
            PlayerPrefs.SetString("data", string.Empty);
            onSuccess?.Invoke();
        }

        string ISave.GetData() => PlayerPrefs.GetString("data", string.Empty);

        void ISave.SaveCloud(Action onSuccess, Action onError)
        {
            PlayerPrefs.SetString("data", "test");
            onSuccess?.Invoke();
        }

        void ISave.SaveLocal(Action onSuccess, Action onError)
        {
            PlayerPrefs.SetString("data", "test");
            onSuccess?.Invoke();
        }


    }
}


