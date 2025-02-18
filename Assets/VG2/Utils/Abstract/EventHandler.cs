using UnityEngine;

namespace VG2
{
    public abstract class EventHandler : MonoBehaviour
    {
        private void OnEnable() => Subscribe();
        private void OnDisable() => Unsubscribe();


        protected abstract void Subscribe();
        protected abstract void Unsubscribe();


    }
}



