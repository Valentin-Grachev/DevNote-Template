using System;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace DevNote.Tutorial.Codestyle
{
    public class Example : MonoBehaviour, ITickable, Zenject.IInitializable
    {
        // В самом верху всегда прописываем реализацию вложенных структур/классов, если они необходимы
        private partial struct LocalData 
        {
            public int id;
            public string name;
        };


        // И затем идет блок всей статики
        public delegate void OnTestComplete(bool success);
        public static event OnTestComplete OnTestCompleted;
        public static bool Initialized => _instance != null;
        private static Static _instance;


        // Далее - события
        public delegate void OnMessageReceive(string message);
        public event OnMessageReceive OnMessageReceived;
        public event OnTestComplete OnLocalTestCompleted;
        public event Action OnCoinsEarned;


        // Сразу после - сериализуемые свойства
        [field: SerializeField] public int SerializableMaxHealth { get; private set; }
        [SerializeField] private int _serializableValue; public int SerializableValue => _serializableValue; // Тут можно в одну строчку, если убирается

        // Дальше - сначала сериализуемые private-переменные
        [SerializeField] private int _maxHealth;
        [SerializeField] private int _damage;
        [SerializeField] private Image _playerIconImage;


        // Дальше идут переменные и свойства - сначала public, потом protected, затем - private

        // Public
        public int MaxHealth { get; private set; }
        public int CurrentHealth { get; set; }

        // Protected
        protected int ProtectedValue { get; set; }

        // Private
        private int PrivateHitCounter { get; set; }
        private string _name;


        // В конце блока переменных и свойств прописываем readonly зависимости
        private readonly Methods methods;

        [Inject] private readonly SerializeFieldVariables variables;
        [Inject] private readonly IAds ads;

        // Затем - все константы
        public string CONTAINER_NAME = "Container";
        private float ANIMATION_DURATION = 2f;


        // И далее блок методов

        public Example() => throw new NotImplementedException();

        void ITickable.Tick() => throw new NotImplementedException();
        void Zenject.IInitializable.Initialize() => throw new NotImplementedException();


        private void Awake() => throw new NotImplementedException();
        private void OnDestroy() => throw new NotImplementedException();
        private void OnEnable() => throw new NotImplementedException();
        private void OnDisable() => throw new NotImplementedException();
        private void Start() => throw new NotImplementedException();
        private void Update() => throw new NotImplementedException();
        private void FixedUpdate() => throw new NotImplementedException();


        public int CalculateRewardCoins() => throw new NotImplementedException();

        protected float CalculateValueFromBaseClass() => throw new NotImplementedException();

        private void MovePlayerToPosition(Vector2 position) => throw new NotImplementedException();

        

        // Обратите внимание, что в классе необходимо прописывать только те элементы, которые действительно необходимы.
        // Если вам не нужны какие-то события - удаляйте их,
        // Если вам не нужен Update - не прописывайте его и так далее для всех остальных элементов.
        // Здесь описан пример на все случаи жизни.

    }


}
