using BeatSaberMarkupLanguage;
using BeatSaberMarkupLanguage.MenuButtons;
using BeatSaberMarkupLanguage.Settings;
using BeatSaberMarkupLanguage.FloatingScreen;
using BeatSaberMarkupLanguage.Util;

namespace CustomMenuText.Views
{
    internal class UICreator
    {
        public static MenuTextFlowCoordinator MenuTextFlowCoordinator;
        public static bool Created;

        async public static void CreateMenu()
        {
            await MainMenuAwaiter.WaitForMainMenuAsync();
            
            if (!Created)
            {
                MenuButton menuButton = new MenuButton("Custom Menu Text", "Manage Custom Menu Text", ShowFlow);
                MenuButtons.Instance.RegisterButton(menuButton);
                Created = true;
            }
        }


        public static void ShowFlow()
        {
            if (MenuTextFlowCoordinator == null)
                MenuTextFlowCoordinator = BeatSaberUI.CreateFlowCoordinator<MenuTextFlowCoordinator>();
            BeatSaberUI.MainFlowCoordinator.PresentFlowCoordinator(MenuTextFlowCoordinator);
        }
    }
}
