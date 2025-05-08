using Modding;
using Satchel.BetterMenus;


namespace GearSwitcher.ModMenu
{
    internal static class BetterMenu
    {
        internal static Menu MenuRef;

        internal static Menu PrepareMenu()
        {
            return new Menu("Gear Switcher", new Element[]{
                Blueprints.NavigateToMenu( "Key Binds","keyboard shortcut change menu",()=> KeyBindsMenu.GetMenu(MenuRef.menuScreen)),
                Blueprints.NavigateToMenu( "Presets configuration","Presets configuration change menu",()=> ListPresetMenu.GetMenu(MenuRef.menuScreen)),


               new HorizontalOption(
                    "Saving collections of charms", "This setting allows you to remember and put on the last put-on charm assembly separately for each preset.",
                    ["False","True"],
                    (setting) => { GearSwitcher.settings.isSaveСollectionsCharms= setting == 1; },
                    () =>  GearSwitcher.settings.isSaveСollectionsCharms?1:0,
                    Id:"isSaveEquippedCharms"),

                new TextPanel(""),

               new HorizontalOption(
                    "Free Charms", "This setting will make all the charms free.",
                    ["False","True"],
                    (setting) => {
                        GearSwitcher.settings.isFreeCharms= setting == 1;
                        GearSwitcher.UpdateCharmsCost();
                    },
                    () =>  GearSwitcher.settings.isFreeCharms?1:0,
                    Id:"isFreeCharms"),

                new TextPanel(""),

                new MenuButton("Set Defult Presets","",(_)=>GearSwitcher.SetDefultSettings())
            });
        }
        internal static MenuScreen GetMenu(MenuScreen lastMenu, ModToggleDelegates? toggleDelegates)
        {
            MenuRef = PrepareMenu();

            return MenuRef.GetMenuScreen(lastMenu);
        }
    }
}