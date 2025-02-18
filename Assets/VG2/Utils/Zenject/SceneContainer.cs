using UnityEngine;
using Zenject;

namespace VG2
{
    public class SceneContainer
    {
        private static DiContainer _container;


        public SceneContainer(DiContainer container)
        {
            _container = container;
        }


        public static GameObject InstantiatePrefab(GameObject prefab, Transform parent = null)
        {
            GameObject instance = Object.Instantiate(prefab, parent);
            _container.InjectGameObject(instance);
            return instance;
        }

        public static T InstantiatePrefabFromComponent<T>(T prefab, Vector3 position, Quaternion quaternion) where T : MonoBehaviour
        {
            T instance = Object.Instantiate(prefab, position, quaternion);
            _container.InjectGameObject(instance.gameObject);
            return instance;
        }

        public static T InstantiatePrefabFromComponent<T>(T prefab, Transform parent = null) where T : MonoBehaviour
        {
            T instance = Object.Instantiate(prefab, parent);
            _container.InjectGameObject(instance.gameObject);
            return instance;
        }


    }
}

