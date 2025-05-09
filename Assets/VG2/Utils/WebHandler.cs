using System;
using UnityEngine;

namespace DevNote.Utils
{
    public class WebHandler : MonoBehaviour
    {
        public static Action onPageBeforeUnload;
        public static Action onPageHidden;


        private void Awake() => DontDestroyOnLoad(gameObject);



        public void JS_OnPageBeforeUnload() => onPageBeforeUnload?.Invoke();

        public void JS_OnPageHidden() => onPageHidden?.Invoke();



    }
}



