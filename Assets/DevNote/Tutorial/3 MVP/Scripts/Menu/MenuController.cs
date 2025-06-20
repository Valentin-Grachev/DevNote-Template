
namespace DevNote.Tutorial.MVP
{
    
    public class MenuController
    {
        // ��� ���������� ������ View � ����� ����� �� ������� �� ����������� ��������� View
        private MenuButtonView _menuButton;

        
        public MenuController(MenuButtonView menuButton)
        {
            _menuButton = menuButton;
        }


        public void HideMenuButton()
        {
            _menuButton.gameObject.SetActive(false);
        }

        public void ShowMenuButton()
        {
            _menuButton.gameObject.SetActive(true);
        }


    }
}

