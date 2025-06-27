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



        // Показ и скрытие окна или любого другого визуального элемента можно делать через
        // Instantiate из префаба и Destroy. Такой подход позволит не захламлять лишними скрытыми элементами основную сцену.
        // Не переживайте - в таких случаях Instantiate и Destroy не будут кушать много ресурсов процессора.
        public void ShowScoreWindow()
        {
            var scoreWindow = _scoreWindowViewer.Show();
            scoreWindow.Display();

            // Обратите внимание, что контроллеры никак не должны вмешиваться в отображение View!
            // Анимации и звуки - это также полностью ответственность View.
            // Здесь мы лишь посылаем ей сигнал на воспроизведение анимации.
            scoreWindow.DisplayShowAnimation();
        }

        public void HideScoreWindow()
        {
            // Аналогично как и с показом - не вмешиваемся в обработку анимации скрытия View.
            // Просто посылаем ей сигнал показа анимации, а затем скрываем View. 
            _scoreWindowViewer.View.DisplayHideAnimation(
                onHidden: () => _scoreWindowViewer.Hide());
        }




    }
}

