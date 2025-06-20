using System;
using UnityEngine;
using Zenject;


namespace DevNote.Tutorial.Codestyle
{
    // Здесь изложены правильные стилистические конструкции в том порядке, в каком они должны объявляться в ваших классах.
    // Пожалуйста, соблюдайте в своих проектах такую стилистику, это во много раз облегчит работу всем программистам.
    // Если какая-то ситуация не описана, то пишите в беседу DevNote https://t.me/+hnsL2UgKKjcwNGMy с просьбой описать здесь вашу ситуацию.


    // Общие рекомендации:

    // === Названия ===
    // Пожалуйста, указывайте названия полей и методов максимально полно и понятно.
    // Не сокращайте названия, даже если они выходят достаточно большими.
    // Это касается как объявления полей, так и локальных переменных.
    // Не оставляйте комментарии в коде, пишите так, чтобы из названий другому программисту все было сразу понятно,
    // что от чего зависит и какой класс что реализует.

    // Хорошие примеры:
    // private float _secondsLeftToFinishCooldown;
    // public void CalculateRewardCoinsAndApplyReward();

    // Плохие примеры, так НЕ делать:
    // private float _timeLeft;     - не понятно, что за время, в секундах ли, в минутах, время до чего?
    // private Image _coinImg;      - не стоит сокращать слова

    // === Размер .cs файлов ===
    // Старайтесь не превышать размер одно скрипта более чем в 300 строк кода.
    // Если у вас один класс раздувается до бОльших размеров - подумайте о том, как его можно разделить
    // на более мелкие классы.

    // Также не употребляйте директивы #region

    // Все публичные классы, структуры, enum - создавайте в отдельных .cs файлах!
    // Не стоит вставлять enum или структуры в общий файл с классом, даже если они очень малы.


    public class InnerClassesStructsEnums // Вложенные классы, структуры, перечисления
    {
        // Это могут быть только private типы данных
        private enum InnerEnumType { }
        private struct InnerStruct { }
        private class InnerClass { }
    }



    public class Static // Статика
    {
        // Все статические переменные и методы идут всегда в самом верху после реализации всех вложенных классов и структур.
        // Порядок объявления в них такой же, как описано в этом файле,
        // только работает отдельно для всех статических элементов.


        // То есть оно выглядит примерно так:

        // Блок статики
        public static event Action OnTested;
        public static bool Initialized => _instance != null;

        private static Static _instance;


        // Блок других нестатических элементов
        public event Action OnLocalTested;
        private bool _localBool;
    }


    public class Events // События
    {
        // Публичные ивенты начинаем с большой буквы и это всегда глагол совершенного вида в английском языке.
        // (То есть почти всегда оканчивается на ed, OnEnabled, OnChanged, OnEarned, OnCompleted
        // Не допускается - OnEnable, OnChange, OnEarn, OnComplete
        public event Action OnCoinsEarned;

        // Если в события необходимо передать параметр, то всегда создаем соответствующий делегат.
        // Не допускается использование Action<тип> !
        // Делегат всегда называем как событие, но в несовершенном виде глагола.
        // То есть OnEnable, OnChange, OnEarn, OnComplete
        public delegate void OnMessageReceive(string message);
        public event OnMessageReceive OnMessageReceived;

    }


    public class SerializeFieldVariables // private-переменные с атрибутом [SerializeField]
    {
        // Такие переменные объявляем с нижним подчеркиванием _
        [SerializeField] private int _maxHealth;
    }


    public class PrivateAndPublicProperties // private и public-свойства
    {
        // Любые свойства с любыми модификаторами доступа объявляем с заглавной буквы
        public int MaxHealth { get; private set; }
        public int CurrentHealth { get; set; }
        private int PrivateHitCounter { get; set; }

        // Такой атрибут позволит сериализовать свойство через инспектор.
        // Используйте такую конструкцию, если вам нужно что-то прокинуть из инспектора,
        // но при этом переменная должна остаться доступной для чтения и закрыта для изменения.
        [field: SerializeField] public int SerializableMaxHealth { get; private set; }


        // Еще альтернативная версия того же самого:
        [SerializeField] private int _serializableValue; public int SerializableValue => _serializableValue;


        // Если мы реализуем наследование, и необходим protected-доступ, то также делаем это через свойства,
        // Не допускается объявление обычных protected-переменных.
        protected int ProtectedValue { get; set; }


    }

    public class Dependencies // Зависимости
    {
        // Если классу необходимо зависеть от других классов-контроллеров или интерфейсов,
        // то мы объявляем зависимости как private readonly и называем их с маленькой буквы без нижнего подчеркивания
        // private readonly объявляется только для контроллеров и для интерфейсов!
        private readonly Methods methods;

        // Зависимости, прокинутые через Zenject, называем в таком же стиле
        [Inject] private readonly SerializeFieldVariables variables;
        [Inject] private readonly IAds ads;

        // В конструкторе пробрасываем зависимости
        public Dependencies(Methods methods)
        {
            this.methods = methods;
        }

    }



    public class Constants // Константы
    {
        // Константы объявляем капслоком
        private float ANIMATION_DURATION = 2f;
        public string CONTAINER_NAME = "Container";
    }


    public class Methods : MonoBehaviour, ITickable // Методы
    {
        // Реализация идет в следующем порядке

        // 1) Конструктор, если он необходим и это не MonoBehaviour-класс
        public Methods() => throw new NotImplementedException();

        // 2) Явная реализация всех интерфейсов
        void ITickable.Tick() => throw new NotImplementedException();


        // 3) Если это MonoBehaviour - реализуем методы в следующем порядке (по мере надобности)
        private void Awake() => throw new NotImplementedException();
        private void OnDestroy() => throw new NotImplementedException();
        private void OnEnable() => throw new NotImplementedException();
        private void OnDisable() => throw new NotImplementedException();
        private void Start() => throw new NotImplementedException();
        private void Update() => throw new NotImplementedException();
        private void FixedUpdate() => throw new NotImplementedException();

        // 4) Далее - обычные методы

        // Сначала идут все public
        public int CalculateRewardCoins() => throw new NotImplementedException();

        // Потом все protected (если есть наследование)
        protected float CalculateValueFromBaseClass() => throw new NotImplementedException();

        // Потом все private
        private void MovePlayerToPosition(Vector2 position) => throw new NotImplementedException();
    }


    public struct Structs // Структуры
    {
        // Публичные поля называем с маленькой буквы
        public int id;
        public string name;

        // Приватные поля называем с нижним подчеркиванием
        private int _handlerId;

        // Правила объявления остальных элементов для структуры такие же, как для классов.
    }


    public enum WeaponType { } // Перечисления называем с большой буквы и всегда с постфиксом Type
    

    public class InterfaceRealiser : ITickable, Zenject.IInitializable // Реализация интерфейсов
    {
        // Все интерфейсы всегда реализуем явно!
        void Zenject.IInitializable.Initialize() => throw new NotImplementedException();
        void ITickable.Tick() => throw new NotImplementedException();

    }



}


