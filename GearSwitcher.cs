using Modding;
using GearSwitcher.ModMenu;
using GearSwitcher.Settings;
using System;
using System.Linq;


namespace GearSwitcher
{
    public class GearSwitcher : Mod, IGlobalSettings<GlobalSettings>, ILocalSettings<LocalSettings>, ICustomMenuMod
    {

        public static GlobalSettings settings = new();

        public static LocalSettings localSettings = new();

        public bool ToggleButtonInsideMenu => true;

        public GearSwitcher() : base(ModInfo.Name) { }
        public void OnLoadGlobal(GlobalSettings s)
        {
            settings = s;
        }
        GlobalSettings IGlobalSettings<GlobalSettings>.OnSaveGlobal()
        {
            return settings;
        }

        public void OnLoadLocal(LocalSettings s)
        {

            localSettings = s;
        }

        public LocalSettings OnSaveLocal()
        {
            return localSettings;
        }
        public override void Initialize()
        {
            base.Initialize();

            On.HeroController.Start += HeroController_Start;
            InputListener.Start();
        }

        private void HeroController_Start(On.HeroController.orig_Start orig, HeroController self)
        {
            orig(self);
            UpdateCharmsCost();
        }

        public static void UpdateCharmsCost()
        {
            if (PlayerData.instance != null && HeroController.instance != null)
            {
                ManagerResurse.MakeFreeCharms(settings.isFreeCharms);
                if (localSettings.LastPreset != null)
                    ManagerResurse.SetPreset(settings.presetEquipments[localSettings.LastPreset]);
                else
                    ManagerResurse.SetPreset(settings.presetEquipments["FullGear"]);

            }

        }

        public MenuScreen GetMenuScreen(MenuScreen modListMenu, ModToggleDelegates? toggleDelegates) =>
            BetterMenu.GetMenu(modListMenu, toggleDelegates);

        public override string GetVersion() => ModInfo.Version;

    }
}