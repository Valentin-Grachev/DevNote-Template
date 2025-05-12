using UnityEngine;

namespace DevNote
{
    public abstract class ReactiveView : MonoBehaviour
    {
        
        protected virtual void OnEnable()
        {
            Subscribe();
            Display();
        }

        protected virtual void OnDisable() => Dispose();


        protected abstract void Subscribe();

        protected abstract void Dispose();

        protected abstract void Display();



    }
}

