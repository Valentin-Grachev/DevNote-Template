using System;

namespace DevNote
{
    public class ReactiveValue<T>
    {
        public event Action onChanged;

        private T _value;

        public T Value 
        { 
            get => _value;
            set
            {
                _value = value;
                onChanged?.Invoke();
            }
        }

        public ReactiveValue(T value)
        {
            _value = value;
        }

    }
}

