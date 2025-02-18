using TMPro;
using UnityEngine;

namespace VG2.Internal
{
    public class VersionLabel : MonoBehaviour
    {
        private void OnEnable() 
            => GetComponent<TextMeshProUGUI>().text = Core.version;
    }
}


