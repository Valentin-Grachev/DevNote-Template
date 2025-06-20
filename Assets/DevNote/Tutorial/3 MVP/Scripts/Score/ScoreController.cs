using UnityEngine;

namespace DevNote.Tutorial.MVP
{
    public class ScoreController : Zenject.IInitializable
    {
        public ReactiveValue<int> CurrentScore { get; private set; } = new(0);


        private ScoreWindowView _scoreWindow;
        private RectTransform _windowContainer;



        public ScoreController(RectTransform windowContainer)
        {
            _windowContainer = windowContainer;
        }


        void Zenject.IInitializable.Initialize()
        {
            CurrentScore.Value = 0;
        }


        public void AddScore() => CurrentScore.Value += Configs.Score.GetScorePerClick(CurrentScore.Value);



        // ����� � ������� ���� ��� ������ ������� ����������� �������� ����� ������ �����
        // Instantiate �� ������� � Destroy. ����� ������ �������� �� ���������� ������� �������� ���������� �������� �����.
        // �� ����������� - � ����� ������� Instantiate � Destroy �� ����� ������ ����� �������� ����������.
        public void ShowScoreWindow()
        {
            _scoreWindow = SceneInjector.InstantiateFromPrefabComponent(Configs.Score.ScoreWindowPrefab, _windowContainer);
            _scoreWindow.Display();

            // �������� ��������, ��� ����������� ����� �� ������ ����������� � ����������� View!
            // �������� � ����� - ��� ����� ��������� ��������������� View.
            // ����� �� ���� �������� �� ������ �� ��������������� ��������.
            _scoreWindow.DisplayShowAnimation();
        }

        public void HideScoreWindow()
        {
            if (_scoreWindow != null)
                Object.Destroy(_scoreWindow.gameObject);
        }




    }
}

