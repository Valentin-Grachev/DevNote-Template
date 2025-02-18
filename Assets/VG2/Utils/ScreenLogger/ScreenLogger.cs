using TMPro;
using UnityEngine;


namespace VG2
{
    public class ScreenLogger : MonoBehaviour
    {
        private static ScreenLogger _instance;

        [SerializeField] private TextMeshProUGUI _messagePrefab;
        [SerializeField] private Transform _container;
        


        private void Awake()
        {
            _instance = this;
        }


        public static void Log(string message)
        {
            var text = Instantiate(_instance._messagePrefab, _instance._container);
            text.text = message;
            text.transform.SetAsFirstSibling();
        }
            




    }
}


