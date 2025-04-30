using Satchel.BetterMenus;
using System;

namespace GearSwitcher.ModMenu
{
    internal class KeyBindsMenu
    {
        private static Menu MenuRef;
        private static MenuScreen MenuScreenRef;

        internal static Menu PrepareMenu()
        {
            try
            {

                Element[] elements = new Element[GearSwitcher.settings.Keybinds.PlayerActions.Length];
                for (int i = 0; i < GearSwitcher.settings.Keybinds.PlayerActions.Length; i++)
                {
                    InControl.PlayerAction bind = GearSwitcher.settings.Keybinds.PlayerActions[i];
                    elements[i] = new KeyBind(bind.Name, bind);
                }
                var menu = new Menu("Keybinds", elements);
                return menu;

            }
            catch (Exception ex)
            {
                Modding.Logger.Log(ex.Message);

            }

            return null;
        }

        internal static MenuScreen GetMenu(MenuScreen lastMenu)
        {
            if (MenuScreenRef == null)
            {
                MenuRef ??= PrepareMenu();
                MenuScreenRef = MenuRef.GetMenuScreen(lastMenu);

            }
            else
            {
                MenuRef.returnScreen = lastMenu;
            }
            return MenuScreenRef;
        }
    }
}