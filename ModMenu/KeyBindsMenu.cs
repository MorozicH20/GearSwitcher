using Satchel.BetterMenus;
using System.Collections.Generic;
namespace GearSwitcher.ModMenu
{
    internal class KeyBindsMenu
    {
        private static Menu MenuRef;
        private static MenuScreen MenuScreenRef;

        internal static Menu PrepareMenu()
        {
            List<Element> elements = new();

            foreach (var bind in GearSwitcher.settings.Keybinds.Actions)
            {
                elements.Add(new KeyBind(bind.Name, bind));
            }

            elements.Add(new MenuButton(
                "Reset Binds", "",
                submitAction: (Mbutton) =>
                {
                    GearSwitcher.ResetBinds();
                },
                Id: "resetBinds"));

            var menu = new Menu("Keybinds", elements.ToArray());
            return menu;
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