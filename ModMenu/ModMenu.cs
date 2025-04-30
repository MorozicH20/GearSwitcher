using Modding;
using Satchel.BetterMenus;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;

namespace GearSwitcher.ModMenu
{
    internal static class BetterMenu
    {
        internal static Menu MenuRef;

        internal static Menu PrepareMenu()
        {
            return new Menu("Custom Knight", new Element[]{
                Blueprints.NavigateToMenu( "Skin List","Opens a list of Skins",()=> KeyBindsMenu.GetMenu(MenuRef.menuScreen)),
                new MenuButton("Set Defult Presets","",(_)=>GearSwitcher.SetDefultPresets())
            });
        }
        internal static MenuScreen GetMenu(MenuScreen lastMenu, ModToggleDelegates? toggleDelegates)
        {
            MenuRef = PrepareMenu();

            return MenuRef.GetMenuScreen(lastMenu);
        }
    }
}