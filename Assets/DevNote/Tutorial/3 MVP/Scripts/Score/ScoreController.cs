using UnityEngine;
using Zenject;

namespace DevNote.Tutorial.MVP
{
    public class ScoreController : IInitializable
    {
        public ReactiveValue<int> CurrentScore { get; private set; } = new(0);

        private Viewer<ScoreWindowView> _scoreWindowViewer;



        public ScoreController(RectTransform windowContainer)
        {
            _scoreWindowViewer = new Viewer<ScoreWindowView>(
                prefab: Configs.Score.ScoreWindowPrefab, 
                container: windowContainer, 
                mode: ViewerMode.InstantiateDestroy);
        }


        void IInitializable.Initialize()
        {
            CurrentScore.Value = 0;
        }


        public void AddScore() => CurrentScore.Value += Configs.Score.GetScorePerClick(CurrentScore.Value);



        // ����� � ������� ���� ��� ������ ������� ����������� �������� ����� ������ �����
        // Instantiate �� ������� � Destroy. ����� ������ �������� �� ���������� ������� �������� ���������� �������� �����.
        // �� ����������� - � ����� ������� Instantiate � Destroy �� ����� ������ ����� �������� ����������.
        public void ShowScoreWindow()
        {
            var scoreWindow = _scoreWindowViewer.Show();
            scoreWindow.Display();

            // �������� ��������, ��� ����������� ����� �� ������ ����������� � ����������� View!
            // �������� � ����� - ��� ����� ��������� ��������������� View.
            // ����� �� ���� �������� �� ������ �� ��������������� ��������.
            scoreWindow.DisplayShowAnimation();
        }

        public void HideScoreWindow()
        {
            // ���������� ��� � � ������� - �� ����������� � ��������� �������� ������� View.
            // ������ �������� �� ������ ������ ��������, � ����� �������� View. 
            _scoreWindowViewer.View.DisplayHideAnimation(
                onHidden: () => _scoreWindowViewer.Hide());
        }




    }
}

