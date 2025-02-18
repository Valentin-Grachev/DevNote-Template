using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.LowLevel;
using UnityEngine.SceneManagement;


namespace VG2
{
    public class Startup : MonoBehaviour
    {
        public static event Action onLoaded;


        public static bool Loaded { get; private set; }

        

        [SerializeField] private List<Initializable> _initializables;
        public List<Initializable> initializables => _initializables;


        private void Awake()
        {
            var loop = PlayerLoop.GetCurrentPlayerLoop();

            foreach (var initializable in _initializables)
                if (initializable.gameObject.activeInHierarchy)
                    initializable.Initialize();

            StartCoroutine(WaitInitializing());
        }


        private IEnumerator WaitInitializing()
        {
            bool allInitialized = false;

            while (!allInitialized)
            {
                allInitialized = true;
                foreach (var initializable in _initializables)
                    if (!initializable.initialized && initializable.gameObject.activeInHierarchy) 
                        allInitialized = false;

                yield return null;
            }


            if (allInitialized)
            {
                SceneManager.LoadScene(1);
                Loaded = true;
                onLoaded?.Invoke();
            }
        }



    }
}


