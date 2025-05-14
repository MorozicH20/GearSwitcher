using Satchel.BetterMenus;
using System.Collections.Generic;
using System.Linq;
namespace GearSwitcher.ModMenu
{
    internal class KeyBindsMenu
    {
        private static Menu MenuRef;
        private static MenuScreen MenuScreenRef;

        internal static Menu PrepareMenu()
        {
            List<Element> elements = new();

            for (int i = 0; i < GearSwitcher.settings.Keybinds.Actions.Count; i++)
            {
                InControl.PlayerAction bind = GearSwitcher.settings.Keybinds.Actions[i];
                elements.Add(new KeyBind(GearSwitcher.settings.presetEquipments.Values.ToArray()[i].Name, bind, Id:$"Key{i}"));
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