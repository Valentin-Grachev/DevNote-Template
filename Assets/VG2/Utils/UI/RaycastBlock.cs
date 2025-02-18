using UnityEngine.UI;
using UnityEngine;
using System.Collections.Generic;

namespace VG2
{
    public static class RaycastBlock
    {
        private const string IGNORE_TAG = "IgnoreRaycastBlock";


        private static bool _enabled = false;


        private static Dictionary<Image, bool> _imageStates = new();


        public static void BlockAll()
        {
            if (_enabled) Disable();

            _imageStates.Clear();

            foreach (var otherImage in Object.FindObjectsOfType<Image>(includeInactive: true))
            {
                if (otherImage.CompareTag(IGNORE_TAG)) continue;

                _imageStates.Add(otherImage, otherImage.raycastTarget);
                otherImage.raycastTarget = false;
            }

            _enabled = true;
        }


        public static void Concentrate(Image image)
        {
            BlockAll();
            image.raycastTarget = true;
        }



        public static void Disable()
        {
            if (!_enabled) return;

            foreach (var imageState in _imageStates)
            {
                if (imageState.Key == null) continue;
                imageState.Key.raycastTarget = imageState.Value;
            }

            _enabled = false;
        }



    }
}

