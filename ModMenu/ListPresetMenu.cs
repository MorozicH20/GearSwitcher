using Satchel.BetterMenus;
using System.Collections.Generic;


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
                if (preset.Key.Contains("Custom"))
                    elements.Add(Blueprints.NavigateToMenu($"{preset.Value.Name}", "", () => PresetConfigurationMenu.GetMenu(MenuRef.menuScreen, preset.Value)));

            }
            var menu = new Menu("List Custom presets", elements.ToArray());
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
