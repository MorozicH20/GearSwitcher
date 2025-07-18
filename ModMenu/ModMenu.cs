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
                Blueprints.NavigateToMenu( "Configure Keybinds","Set custom keyboard shortcuts for each preset",()=> KeyBindsMenu.GetMenu(MenuRef.menuScreen)),
                Blueprints.NavigateToMenu( "Configure Custom Presets","Manage and customize your presets",()=> ListPresetMenu.GetMenu(MenuRef.menuScreen)),


               new HorizontalOption(
                    "Save Charms", "If this setting is enabled, a preset will also save your charm build",
                    ["False","True"],
                    (setting) => { GearSwitcher.settings.isSaveСollectionsCharms= setting == 1; },
                    () =>  GearSwitcher.settings.isSaveСollectionsCharms?1:0,
                    Id:"isSaveEquippedCharms"),

                //new TextPanel(""),

               new HorizontalOption(
                    "Free Charms", "This setting makes all charms cost 0 notches",
                    ["False","True"],
                    (setting) => {
                        GearSwitcher.settings.isFreeCharms= setting == 1;
                        GearSwitcher.UpdateCharmsCost();
                    },
                    () =>  GearSwitcher.settings.isFreeCharms?1:0,
                    Id:"isFreeCharms"),

                //new TextPanel(""),

                new MenuButton("Reset to Defaults","",(_)=>GearSwitcher.SetDefultSettings())
            });
        }
        internal static MenuScreen GetMenu(MenuScreen lastMenu, ModToggleDelegates? toggleDelegates)
        {
            MenuRef = PrepareMenu();

            return MenuRef.GetMenuScreen(lastMenu);
        }
    }
}