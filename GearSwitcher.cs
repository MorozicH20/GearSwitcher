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
        public override void Initialize()
        {
            base.Initialize();

            if (settings.presetEquipments == null || settings.Keybinds == null)
            {
                SetDefultPresets();
            }
            InputListener.Start();

        }

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

            }
            catch (Exception ex)
            {
                Modding.Logger.LogError(ex.ToString());
            }

        }

        GlobalSettings IGlobalSettings<GlobalSettings>.OnSaveGlobal()
        {
            if (settings.presetEquipments == null)
            {
                SetDefultPresets();
            }

            return settings;
        }


        public static void SetDefultPresets()
        {
            var FullSave = DefaultPresets.FullSave();
            var O4 = DefaultPresets.O4();
            var Ow = DefaultPresets.Ow();
            var ItemLess = DefaultPresets.ItemLess();
            var NMA = DefaultPresets.NMA();
            var NNA = DefaultPresets.NNA();
            var NailOnly = DefaultPresets.NailOnly();

            settings.presetEquipments = new() {
                { FullSave.Name, FullSave },
                { O4.Name, O4 },
                { Ow.Name, Ow },
                { ItemLess.Name, ItemLess },
                { NMA.Name, NMA },
                { NNA.Name, NNA },
                { NailOnly.Name,NailOnly  },

             };
            settings.Keybinds = new(settings.presetEquipments);


        }


        public MenuScreen GetMenuScreen(MenuScreen modListMenu, ModToggleDelegates? toggleDelegates) =>
            BetterMenu.GetMenu(modListMenu, toggleDelegates);

        public override string GetVersion() => ModInfo.Version;
    }
}