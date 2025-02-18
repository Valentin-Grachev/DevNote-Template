using R3;
using UnityEngine;
using Zenject;

namespace VG2
{
    public abstract class ReactiveEvent : MonoBehaviour
    {
        protected readonly CompositeDisposable disposables = new CompositeDisposable();


        protected virtual void OnEnable() => Subscribe();


        private void OnDisable() => disposables.Dispose();


        protected abstract void Subscribe();

    }
}

