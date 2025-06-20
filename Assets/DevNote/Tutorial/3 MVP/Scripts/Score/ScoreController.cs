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



        // Показ и скрытие окна или любого другого визуального элемента можно делать через
        // Instantiate из префаба и Destroy. Такой подход позволит не захламлять лишними скрытыми элементами основную сцену.
        // Не переживайте - в таких случаях Instantiate и Destroy не будут кушать много ресурсов процессора.
        public void ShowScoreWindow()
        {
            _scoreWindow = SceneInjector.InstantiateFromPrefabComponent(Configs.Score.ScoreWindowPrefab, _windowContainer);
            _scoreWindow.Display();

            // Обратите внимание, что контроллеры никак не должны вмешиваться в отображение View!
            // Анимации и звуки - это также полностью ответственность View.
            // Здесь мы лишь посылаем ей сигнал на воспроизведение анимации.
            _scoreWindow.DisplayShowAnimation();
        }

        public void HideScoreWindow()
        {
            if (_scoreWindow != null)
                Object.Destroy(_scoreWindow.gameObject);
        }




    }
}

