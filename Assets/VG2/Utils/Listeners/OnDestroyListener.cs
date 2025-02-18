using System;
using UnityEngine;

namespace VG2
{
    public class OnDestroyListener : MonoBehaviour
    {
        public event Action onDestroy;

        private void OnDestroy() => onDestroy?.Invoke();


    }

    public static class OnDestroyListenerExtension
    {
        public static OnDestroyListener AttachOnDestroyListener(this GameObject gameObject, Action onDestroy)
        {
            var listener = gameObject.AddComponent<OnDestroyListener>();
            listener.onDestroy += onDestroy;
            return listener;
        }


    }




}

