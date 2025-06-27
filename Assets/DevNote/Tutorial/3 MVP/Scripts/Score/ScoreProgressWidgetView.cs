using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace DevNote.Tutorial.MVP
{

    // ����� �� ���������� ScoreWindowView, �� ������ ���������� ������ View,
    // �������� �� Display() ����� ������������ ������ � �� ��� ��� ������ ���� ���������
    public class ScoreProgressWidgetView : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _scoreText;
        [SerializeField] private Slider _progressBarSlider;


        public void Display(int currentScore, int requiredScore)
        {
            if (Configs.Score.IsMaxLevel(currentScore))
            {
                _scoreText.text = "Maximum!";
                _progressBarSlider.value = 1f;
            }
            else
            {
                _scoreText.text = $"{currentScore}/{requiredScore}";
                _progressBarSlider.value = (float)currentScore / requiredScore;
            }
        }


    }
}

