using System;
using UnityEngine;


namespace VG2
{
    public abstract class Initializable : MonoBehaviour
    {
        public bool initialized { get; private set; }
        public event Action onInitialized;

        public abstract void Initialize();

        protected virtual void OnInitialized() { }

        protected void InitCompleted()
        {
            initialized = true;
            OnInitialized();
            onInitialized?.Invoke();
        }




    }
}


