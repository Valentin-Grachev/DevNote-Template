
namespace DevNote.Tutorial.MVP
{
    
    public class MenuController
    {
        // ��� ���������� ������� / �������� ������ ���������� Viewer
        private Viewer<MenuButtonView> _menuButtonViewer;

        
        public MenuController(MenuButtonView menuButton)
        {
            _menuButtonViewer = new Viewer<MenuButtonView>(menuButton);
        }


        public void HideMenuButton()
        {
            _menuButtonViewer.Hide();
        }

        public void ShowMenuButton()
        {
            _menuButtonViewer.Show();
        }


    }
}

