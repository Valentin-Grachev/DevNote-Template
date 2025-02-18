using UnityEngine;

namespace VG2.Internal
{
    public class GlobalObject : MonoBehaviour
    {

        private void Awake()
        {
            transform.SetParent(null);
            DontDestroyOnLoad(gameObject);
        }
    }
}


