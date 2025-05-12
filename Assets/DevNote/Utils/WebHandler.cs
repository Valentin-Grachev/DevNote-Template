using System;
using UnityEngine;

namespace DevNote
{
    public class WebHandler : MonoBehaviour
    {
        public static Action onPageBeforeUnload;
        public static Action onPageHidden;


        public void JS_OnPageBeforeUnload() => onPageBeforeUnload?.Invoke();

        public void JS_OnPageHidden() => onPageHidden?.Invoke();



    }
}



