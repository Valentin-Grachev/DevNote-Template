using UnityEngine;

namespace VG2
{
    public class AvailableOnlyControl : MonoBehaviour
    {
        [SerializeField] private ControlType _controlType;


        private void OnEnable()
        {
            if (DeviceInfo.ControlType != _controlType)
                gameObject.SetActive(false);
        }

    }
}

