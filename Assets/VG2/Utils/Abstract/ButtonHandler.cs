using System;
using UnityEngine;
using UnityEngine.UI;


namespace VG2
{
    [RequireComponent(typeof(Button))]
    public abstract class ButtonHandler : MonoBehaviour
    {
        public event Action onCompleted;
        private Button _button;

        public Button button 
        { 
            get
            {
                _button ??= GetComponent<Button>();
                return _button;
            }
        }


        protected virtual void Start()
        {
            _button = GetComponent<Button>();
            _button.onClick.AddListener(OnButtonClicked);
        }

        private void OnButtonClicked()
        {
            OnClick();
            onCompleted?.Invoke();
        }

        protected abstract void OnClick();

    }
}


