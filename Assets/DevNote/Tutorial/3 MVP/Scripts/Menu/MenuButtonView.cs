using DevNote.Tutorial.MVP;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

public class MenuButtonView : MonoBehaviour
{
    // View �� ����� ���� �� ������ �����������, ��� ������ Presenter, ��� ��� �� ����� �������� ������� �� ������������
    // � ���� �������� �� ������� ������
    [SerializeField] private Button _startButton;

    [Inject] private readonly MenuController menuController;
    [Inject] private readonly ScoreController scoreController;



    private void Start()
    {
        _startButton.onClick.AddListener(OnStartButtonClick);
    }

    private void OnStartButtonClick()
    {
        menuController.HideMenuButton();
        scoreController.ShowScoreWindow();
    }


}
