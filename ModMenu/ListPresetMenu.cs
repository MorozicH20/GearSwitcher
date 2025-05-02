using Satchel.BetterMenus;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GearSwitcher.ModMenu
{
    internal class ListPresetMenu
    {
        private static Menu MenuRef;
        private static MenuScreen MenuScreenRef;

        internal static Menu PrepareMenu()
        {
            List<Element> elements = new List<Element>();

            foreach (var preset in GearSwitcher.settings.presetEquipments)
            {
                elements.Add(Blueprints.NavigateToMenu($"{preset.Key}", "", () => PresetConfigurationMenu.GetMenu(MenuRef.menuScreen, preset.Value)));
            }
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
