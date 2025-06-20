using UnityEngine;
using Zenject;

namespace DevNote
{
    public class SceneInjector
    {
        private static DiContainer _container;


        public SceneInjector(DiContainer container)
        {
            _container = container;
        }


        public static GameObject InstantiateFromPrefab(GameObject prefab, Transform parent = null)
        {
            return _container.InstantiatePrefab(prefab, parent);
        }

        public static GameObject InstantiateFromPrefab(GameObject prefab, Vector3 position, Quaternion quaternion)
        {
            GameObject instance = _container.InstantiatePrefab(prefab);
            instance.transform.position = position;
            instance.transform.rotation = quaternion;
            return instance;
        }

        public static T InstantiateFromPrefabComponent<T>(T prefab, Vector3 position, Quaternion quaternion) where T : Component
        {
            T instance = _container.InstantiatePrefabForComponent<T>(prefab);
            instance.transform.position = position;
            instance.transform.rotation = quaternion;
            return instance;
        }

        public static T InstantiateFromPrefabComponent<T>(T prefab, Transform parent = null) where T : Component
        {
            return _container.InstantiatePrefabForComponent<T>(prefab, parent);
        }


    }
}

