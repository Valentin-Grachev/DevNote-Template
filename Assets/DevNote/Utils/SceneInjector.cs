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
            GameObject instance = Object.Instantiate(prefab, parent);
            _container.InjectGameObject(instance);
            return instance;
        }

        public static GameObject InstantiateFromPrefab(GameObject prefab, Vector3 position, Quaternion quaternion)
        {
            GameObject instance = Object.Instantiate(prefab, position, quaternion);
            _container.InjectGameObject(instance);
            return instance;
        }

        public static T InstantiateFromPrefabComponent<T>(T prefab, Vector3 position, Quaternion quaternion) where T : Component
        {
            T instance = Object.Instantiate(prefab, position, quaternion);
            _container.InjectGameObject(instance.gameObject);
            return instance;
        }

        public static T InstantiateFromPrefabComponent<T>(T prefab, Transform parent = null) where T : Component
        {
            T instance = Object.Instantiate(prefab, parent);
            _container.InjectGameObject(instance.gameObject);
            return instance;
        }


    }
}

