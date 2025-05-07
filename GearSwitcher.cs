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
            if (s == null)
            {
                SetDefultPresets();
                return;
            }
            settings = s;


            if (settings.presetEquipments.Count < 1)
                ResetPresets();

            if (settings.Keybinds.Actions.Count < 1)
                ResetBinds();


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

            if (settings.presetEquipments.Count < 1)
                ResetPresets();

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
                    ManagerResurse.SetPreset(settings.presetEquipments["FullSave"]);

            }

        }
        public static void ResetPresets()
        {
            var FullSave = DefaultPresets.FullSave();
            var Ab = DefaultPresets.Ab();
            var O4 = DefaultPresets.O4();
            var Ow = DefaultPresets.Ow();
            var ItemLess = DefaultPresets.ItemLess();
            var NMA = DefaultPresets.NMA();
            var NNA = DefaultPresets.NNA();
            var NailOnly = DefaultPresets.NailOnly();

            var Custom1 = DefaultPresets.FullSave();
            Custom1.Name = "Custom1";

            var Custom2 = DefaultPresets.FullSave();
            Custom2.Name = "Custom2";

            var Custom3 = DefaultPresets.FullSave();
            Custom3.Name = "Custom3";

            var Custom4 = DefaultPresets.FullSave();
            Custom4.Name = "Custom4";

            var Custom5 = DefaultPresets.FullSave();
            Custom5.Name = "Custom5";

            settings.presetEquipments = new() {
                { FullSave.Name, FullSave },
                { Ab.Name,Ab  },
                { O4.Name, O4 },
                { Ow.Name, Ow },
                { ItemLess.Name, ItemLess },
                { NMA.Name, NMA },
                { NNA.Name, NNA },
                { NailOnly.Name,NailOnly  },

                { Custom1.Name, Custom1 },
                { Custom2.Name, Custom2 },
                { Custom3.Name, Custom3 },
                { Custom4.Name, Custom4 },
                { Custom5.Name, Custom5 },


             };

        }
        public static void ResetBinds()
        {
            settings.Keybinds = new();

        }
        public static void SetDefultPresets()
        {
            ResetPresets();
            ResetBinds();

        }


        public MenuScreen GetMenuScreen(MenuScreen modListMenu, ModToggleDelegates? toggleDelegates) =>
            BetterMenu.GetMenu(modListMenu, toggleDelegates);

        public override string GetVersion() => ModInfo.Version;

    }
}