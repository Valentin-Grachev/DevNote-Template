
namespace DevNote.Tutorial.MVP
{
    
    public class MenuController
    {
        // При объявлении любого View в любом месте мы никогда не приписываем постфикса View
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

