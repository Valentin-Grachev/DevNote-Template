using UnityEngine;

namespace DevNote
{
    public class RootObject : MonoBehaviour
    {

        private void Awake()
        {
            transform.SetParent(null);
            DontDestroyOnLoad(gameObject);
        }
    }
}


