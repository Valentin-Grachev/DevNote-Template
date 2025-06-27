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
        // ����� ��������� ������������� ����, ������� ����� ������������ ����� ���������
        [SerializeField] private ScoreProgressWidgetView _scoreProgressWidget;
        [SerializeField] private Button _addButton;
        [SerializeField] private Button _switchAdsButton;
        [SerializeField] private Button _closeButton;
        [SerializeField] private Image _adsEnabledImage;
        [SerializeField] private Color _adsDisabledColor;
        [SerializeField] private Color _adsEnabledColor;

        // ���� ����������� ����������� �� �����������. ��� ������������ ����� ������ ������������ �������� Controller.
        // ����������� ������ ����� �������� [Inject], �� ���������� ����� Construct() � �� ����������� ������ �������.
        [Inject] private readonly ScoreController scoreController;
        [Inject] private readonly MenuController menuController;

        // �������� ��������, ��� ��������� ��� �������� ������������� �����������
        private const float SHOW_ANIMATION_DURATION = 1f;


        private void OnEnable()
        {
            // �� ������� ������������� � OnEnable
            scoreController.CurrentScore.OnChanged += Display;
            GameState.AdsEnabled.OnChanged += Display;
        }
        private void OnDisable()
        {
            // �� ������� ���������� � OnEnable
            scoreController.CurrentScore.OnChanged -= Display;
            GameState.AdsEnabled.OnChanged -= Display;
        }

        private void Start()
        {
            // �� ���� ������� � ���� ������ ������������� ����� ������� � ������ Start!
            // ������� �� ���������� Unity Action ����� ���������, � ��� ���� �������!
            // ������� �� ������� ������� ������ �� ���������.
            _addButton.onClick.AddListener(OnAddButtonClick);
            _switchAdsButton.onClick.AddListener(OnSwitchAdsButtonClick);
            _closeButton.onClick.AddListener(OnCloseButtonClick);
        }

        private void OnCloseButtonClick()
        {
            scoreController.HideScoreWindow();
            menuController.ShowMenuButton();
        }


        // ��� �������� �� ������� ����� ������������ ����� ����� Display() - ��� ������� ��� ������ View
        public void Display()
        {
            int currentScore = scoreController.CurrentScore.Value;

            // �������� ��� ��������� � ������ �� ��� �������� ������ �� ��������
            int requiredScore = Configs.Score.GetScoreRequireForNextLevel(currentScore);

            // �������� ��� ��������� � ������� ���������� ����������� ����� �� ������,
            // ������ ����, ����� �������� � ���� ����� �������������� ������.
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


        // ������������ �� ������� ������, ������ ������� ����� � ��������� On � ���������� Click, ��� ���.
        // ������� �� ���������� � onClick.AddListener() �����-�� ����� ��������.
        private void OnAddButtonClick() => scoreController.AddScore();


        // ��� ������ �������� ������ � ���� ������� ����� ��������� ������ ��� �����������-����������
        private void OnSwitchAdsButtonClick() => GameState.AdsEnabled.Value = !GameState.AdsEnabled.Value;

    }
}



