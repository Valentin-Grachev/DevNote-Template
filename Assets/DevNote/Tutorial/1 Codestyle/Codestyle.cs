using System;
using UnityEngine;
using Zenject;


namespace DevNote.Tutorial.Codestyle
{
    // ����� �������� ���������� �������������� ����������� � ��� �������, � ����� ��� ������ ����������� � ����� �������.
    // ����������, ���������� � ����� �������� ����� ����������, ��� �� ����� ��� �������� ������ ���� �������������.
    // ���� �����-�� �������� �� �������, �� ������ � ������ DevNote https://t.me/+hnsL2UgKKjcwNGMy � �������� ������� ����� ���� ��������.


    // ����� ������������:

    // === �������� ===
    // ����������, ���������� �������� ����� � ������� ����������� ����� � �������.
    // �� ���������� ��������, ���� ���� ��� ������� ���������� ��������.
    // ��� �������� ��� ���������� �����, ��� � ��������� ����������.
    // �� ���������� ����������� � ����, ������ ���, ����� �� �������� ������� ������������ ��� ���� ����� �������,
    // ��� �� ���� ������� � ����� ����� ��� ���������.

    // ������� �������:
    // private float _secondsLeftToFinishCooldown;
    // public void CalculateRewardCoinsAndApplyReward();

    // ������ �������, ��� �� ������:
    // private float _timeLeft;     - �� �������, ��� �� �����, � �������� ��, � �������, ����� �� ����?
    // private Image _coinImg;      - �� ����� ��������� �����

    // === ������ .cs ������ ===
    // ���������� �� ��������� ������ ���� ������� ����� ��� � 300 ����� ����.
    // ���� � ��� ���� ����� ����������� �� ������� �������� - ��������� � ���, ��� ��� ����� ���������
    // �� ����� ������ ������.

    // ����� �� ������������ ��������� #region

    // ��� ��������� ������, ���������, enum - ���������� � ��������� .cs ������!
    // �� ����� ��������� enum ��� ��������� � ����� ���� � �������, ���� ���� ��� ����� ����.


    public class InnerClassesStructsEnums // ��������� ������, ���������, ������������
    {
        // ��� ����� ���� ������ private ���� ������
        private enum InnerEnumType { }
        private struct InnerStruct { }
        private class InnerClass { }
    }



    public class Static // �������
    {
        // ��� ����������� ���������� � ������ ���� ������ � ����� ����� ����� ���������� ���� ��������� ������� � ��������.
        // ������� ���������� � ��� ����� ��, ��� ������� � ���� �����,
        // ������ �������� �������� ��� ���� ����������� ���������.


        // �� ���� ��� �������� �������� ���:

        // ���� �������
        public static event Action OnTested;
        public static bool Initialized => _instance != null;

        private static Static _instance;


        // ���� ������ ������������� ���������
        public event Action OnLocalTested;
        private bool _localBool;
    }


    public class Events // �������
    {
        // ��������� ������ �������� � ������� ����� � ��� ������ ������ ������������ ���� � ���������� �����.
        // (�� ���� ����� ������ ������������ �� ed, OnEnabled, OnChanged, OnEarned, OnCompleted
        // �� ����������� - OnEnable, OnChange, OnEarn, OnComplete
        public event Action OnCoinsEarned;

        // ���� � ������� ���������� �������� ��������, �� ������ ������� ��������������� �������.
        // �� ����������� ������������� Action<���> !
        // ������� ������ �������� ��� �������, �� � ������������� ���� �������.
        // �� ���� OnEnable, OnChange, OnEarn, OnComplete
        public delegate void OnMessageReceive(string message);
        public event OnMessageReceive OnMessageReceived;

    }


    public class SerializeFieldVariables // private-���������� � ��������� [SerializeField]
    {
        // ����� ���������� ��������� � ������ �������������� _
        [SerializeField] private int _maxHealth;
    }


    public class PrivateAndPublicProperties // private � public-��������
    {
        // ����� �������� � ������ �������������� ������� ��������� � ��������� �����
        public int MaxHealth { get; private set; }
        public int CurrentHealth { get; set; }
        private int PrivateHitCounter { get; set; }

        // ����� ������� �������� ������������� �������� ����� ���������.
        // ����������� ����� �����������, ���� ��� ����� ���-�� ��������� �� ����������,
        // �� ��� ���� ���������� ������ �������� ��������� ��� ������ � ������� ��� ���������.
        [field: SerializeField] public int SerializableMaxHealth { get; private set; }


        // ��� �������������� ������ ���� �� ������:
        [SerializeField] private int _serializableValue; public int SerializableValue => _serializableValue;


        // ���� �� ��������� ������������, � ��������� protected-������, �� ����� ������ ��� ����� ��������,
        // �� ����������� ���������� ������� protected-����������.
        protected int ProtectedValue { get; set; }


    }

    public class Dependencies // �����������
    {
        // ���� ������ ���������� �������� �� ������ �������-������������ ��� �����������,
        // �� �� ��������� ����������� ��� private readonly � �������� �� � ��������� ����� ��� ������� �������������
        // private readonly ����������� ������ ��� ������������ � ��� �����������!
        private readonly Methods methods;

        // �����������, ���������� ����� Zenject, �������� � ����� �� �����
        [Inject] private readonly SerializeFieldVariables variables;
        [Inject] private readonly IAds ads;

        // � ������������ ������������ �����������
        public Dependencies(Methods methods)
        {
            this.methods = methods;
        }

    }



    public class Constants // ���������
    {
        // ��������� ��������� ���������
        private float ANIMATION_DURATION = 2f;
        public string CONTAINER_NAME = "Container";
    }


    public class Methods : MonoBehaviour, ITickable // ������
    {
        // ���������� ���� � ��������� �������

        // 1) �����������, ���� �� ��������� � ��� �� MonoBehaviour-�����
        public Methods() => throw new NotImplementedException();

        // 2) ����� ���������� ���� �����������
        void ITickable.Tick() => throw new NotImplementedException();


        // 3) ���� ��� MonoBehaviour - ��������� ������ � ��������� ������� (�� ���� ����������)
        private void Awake() => throw new NotImplementedException();
        private void OnDestroy() => throw new NotImplementedException();
        private void OnEnable() => throw new NotImplementedException();
        private void OnDisable() => throw new NotImplementedException();
        private void Start() => throw new NotImplementedException();
        private void Update() => throw new NotImplementedException();
        private void FixedUpdate() => throw new NotImplementedException();

        // 4) ����� - ������� ������

        // ������� ���� ��� public
        public int CalculateRewardCoins() => throw new NotImplementedException();

        // ����� ��� protected (���� ���� ������������)
        protected float CalculateValueFromBaseClass() => throw new NotImplementedException();

        // ����� ��� private
        private void MovePlayerToPosition(Vector2 position) => throw new NotImplementedException();
    }


    public struct Structs // ���������
    {
        // ��������� ���� �������� � ��������� �����
        public int id;
        public string name;

        // ��������� ���� �������� � ������ ��������������
        private int _handlerId;

        // ������� ���������� ��������� ��������� ��� ��������� ����� ��, ��� ��� �������.
    }


    public enum WeaponType { } // ������������ �������� � ������� ����� � ������ � ���������� Type
    

    public class InterfaceRealiser : ITickable, Zenject.IInitializable // ���������� �����������
    {
        // ��� ���������� ������ ��������� ����!
        void Zenject.IInitializable.Initialize() => throw new NotImplementedException();
        void ITickable.Tick() => throw new NotImplementedException();

    }



}


