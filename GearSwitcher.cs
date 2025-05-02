using System;
using System.Collections;
using System.Collections.Generic;
using Modding;
using UnityEngine;
using UObject = UnityEngine.Object;
using ToggleableBindings;
using UnityEngine.PlayerLoop;
using GearSwitcher.ModMenu;
using GearSwitcher.Settings;
namespace GearSwitcher
{
    public class GearSwitcher : Mod, IGlobalSettings<GlobalSettings>, ICustomMenuMod
    {

        public static GlobalSettings settings = new();

        public bool ToggleButtonInsideMenu => true;

        public GearSwitcher() : base(ModInfo.Name) { }
        public void OnLoadGlobal(GlobalSettings s)
        {
            try
            {
                if (s == null)
                {
                    SetDefultPresets();
                    return;
                }
                settings = s;

                if (settings.presetEquipments.Count < 1)
                {
                    ResetPresets();
                }
                Modding.Logger.Log($"{settings.presetEquipments}");


                if (settings.Keybinds.Actions.Count < 1)
                    ResetBinds();
                Modding.Logger.Log($"{settings.Keybinds.Actions.Count}");

            }
            catch (Exception ex)
            {
                Modding.Logger.LogError(ex.ToString());
            }

        }
        public override void Initialize()
        {
            base.Initialize();

            //if (settings.presetEquipments == null
            //    || settings.Keybinds == null
            //    || settings.Keybinds.Actions == null
            //    || settings.presetEquipments.Count < 1
            //    || settings.Keybinds.Actions.Count < 1)
            //{
            //    SetDefultPresets();
            //}
            InputListener.Start();

        }


        GlobalSettings IGlobalSettings<GlobalSettings>.OnSaveGlobal()
        {
            return settings;
        }

        public static void ResetPresets()
        {
            var FullSave = DefaultPresets.FullSave();
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
            Modding.Logger.LogWarn("Set Defult Presets");

        }
        public static void ResetBinds()
        {
            settings.Keybinds = new();
            Modding.Logger.LogWarn("Set Defult Binds");

        }
        public static void SetDefultPresets()
        {
            ResetPresets();
            ResetBinds();

            Modding.Logger.LogWarn("Set Defult Presets\\Binds");
        }


        public MenuScreen GetMenuScreen(MenuScreen modListMenu, ModToggleDelegates? toggleDelegates) =>
            BetterMenu.GetMenu(modListMenu, toggleDelegates);

        public override string GetVersion() => ModInfo.Version;
    }
}