using System;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace DevNote.Tutorial.Codestyle
{
    public class Example : MonoBehaviour, ITickable, Zenject.IInitializable
    {
        // � ����� ����� ������ ����������� ���������� ��������� ��������/�������, ���� ��� ����������
        private partial struct LocalData 
        {
            public int id;
            public string name;
        };


        // � ����� ���� ���� ���� �������
        public delegate void OnTestComplete(bool success);
        public static event OnTestComplete OnTestCompleted;
        public static bool Initialized => _instance != null;
        private static Static _instance;


        // ����� - �������
        public delegate void OnMessageReceive(string message);
        public event OnMessageReceive OnMessageReceived;
        public event OnTestComplete OnLocalTestCompleted;
        public event Action OnCoinsEarned;


        // ����� ����� - ������������� ��������
        [field: SerializeField] public int SerializableMaxHealth { get; private set; }
        [SerializeField] private int _serializableValue; public int SerializableValue => _serializableValue; // ��� ����� � ���� �������, ���� ���������

        // ������ - ������� ������������� private-����������
        [SerializeField] private int _maxHealth;
        [SerializeField] private int _damage;
        [SerializeField] private Image _playerIconImage;


        // ������ ���� ���������� � �������� - ������� public, ����� protected, ����� - private

        // Public
        public int MaxHealth { get; private set; }
        public int CurrentHealth { get; set; }

        // Protected
        protected int ProtectedValue { get; set; }

        // Private
        private int PrivateHitCounter { get; set; }
        private string _name;


        // � ����� ����� ���������� � ������� ����������� readonly �����������
        private readonly Methods methods;

        [Inject] private readonly SerializeFieldVariables variables;
        [Inject] private readonly IAds ads;

        // ����� - ��� ���������
        public string CONTAINER_NAME = "Container";
        private float ANIMATION_DURATION = 2f;


        // � ����� ���� �������

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

        

        // �������� ��������, ��� � ������ ���������� ����������� ������ �� ��������, ������� ������������� ����������.
        // ���� ��� �� ����� �����-�� ������� - �������� ��,
        // ���� ��� �� ����� Update - �� ������������ ��� � ��� ����� ��� ���� ��������� ���������.
        // ����� ������ ������ �� ��� ������ �����.

    }


}
