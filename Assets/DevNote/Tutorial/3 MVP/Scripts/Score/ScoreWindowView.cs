using System;
using DG.Tweening;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Zenject;


namespace DevNote.Tutorial.MVP
{
    public class ScoreWindowView : MonoBehaviour
    {
        // Здесь указываем сериализуемые поля, которые будем пробрасывать через инспектор
        [SerializeField] private ScoreProgressWidgetView _scoreProgressWidget;
        [SerializeField] private Button _addButton;
        [SerializeField] private Button _switchAdsButton;
        [SerializeField] private Button _closeButton;
        [SerializeField] private Image _adsEnabledImage;
        [SerializeField] private Color _adsDisabledColor;
        [SerializeField] private Color _adsEnabledColor;

        // Сюда прокидываем зависимость от контроллера. Для контроллеров здесь всегда приписывайте постфикс Controller.
        // Используйте только через аттрибут [Inject], не создавайте метод Construct() и не используйте другие способы.
        [Inject] private readonly ScoreController scoreController;
        [Inject] private readonly MenuController menuController;

        // Обратите внимание, что параметры для анимации прописываются константами
        private const float SHOW_ANIMATION_DURATION = 1f;


        private void OnEnable()
        {
            // На события подписываемся в OnEnable
            scoreController.CurrentScore.OnChanged += Display;
            GameState.AdsEnabled.OnChanged += Display;
        }
        private void OnDisable()
        {
            // На события отписываем в OnEnable
            scoreController.CurrentScore.OnChanged -= Display;
            GameState.AdsEnabled.OnChanged -= Display;
        }

        private void Start()
        {
            // Ко всем кнопкам в игре всегда подписываемся через скрипты в методе Start!
            // Никогда не используем Unity Action через инспектор, у них куча проблем!
            // Отписка от событий нажатия кнопки не требуется.
            _addButton.onClick.AddListener(OnAddButtonClick);
            _switchAdsButton.onClick.AddListener(OnSwitchAdsButtonClick);
            _closeButton.onClick.AddListener(OnCloseButtonClick);
        }

        private void OnCloseButtonClick()
        {
            scoreController.HideScoreWindow();
            menuController.ShowMenuButton();
        }


        // При подписке на событие можно использовать общий метод Display() - его создаем для многих View
        public void Display()
        {
            int currentScore = scoreController.CurrentScore.Value;

            // Смотрите как аккуратно и удобно мы тут получаем данные из конфигов
            int requiredScore = Configs.Score.GetScoreRequireForNextLevel(currentScore);

            // Смотрите как аккуратно и красиво делегируем отображение счета на виджет,
            // вместо того, чтобы городить в этой вьюхе дополнительную логику.
            _scoreProgressWidget.Display(currentScore, requiredScore);

            _adsEnabledImage.color = GameState.AdsEnabled.Value ? _adsEnabledColor : _adsDisabledColor;
        }

        public void DisplayShowAnimation()
        {
            transform.localScale = Vector3.zero;
            transform.DOScale(1f, SHOW_ANIMATION_DURATION).SetEase(Ease.OutFlash);
        }

        public void DisplayHideAnimation(Action onHidden = null)
        {
            transform.DOScale(0f, SHOW_ANIMATION_DURATION).SetEase(Ease.OutFlash)
                .onComplete += () => onHidden?.Invoke();
        }


        // Подписываясь на событие кнопки, всегда создаем метод с префиксом On и постфиксом Click, как тут.
        // Никогда не добавляйте в onClick.AddListener() какой-то метод напрямую.
        private void OnAddButtonClick() => scoreController.AddScore();


        // Для совсем короткой логики в одну строчку можно выполнять логику без контроллера-посредника
        private void OnSwitchAdsButtonClick() => GameState.AdsEnabled.Value = !GameState.AdsEnabled.Value;

    }
}



