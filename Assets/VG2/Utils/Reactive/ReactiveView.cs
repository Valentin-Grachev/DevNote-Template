using System;
using System.Collections.Generic;
using UnityEngine;

namespace VG2
{
    public abstract class ReactiveView : MonoBehaviour
    {
        protected readonly List<IDisposable> disposables = new();


        protected virtual void OnEnable()
        {
            Subscribe();
            Display();
        }

        private void OnDisable()
        {
            foreach (var disposable in disposables) 
                disposable.Dispose();
        }


        protected abstract void Subscribe();

        protected abstract void Display();



    }
}

