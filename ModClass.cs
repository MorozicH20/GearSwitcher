using System;
using System.Collections;
using System.Collections.Generic;
using Modding;
using UnityEngine;
using UObject = UnityEngine.Object;
//using HelperForChallenge.PresetEquipment;
using ToggleableBindings;
using UnityEngine.PlayerLoop;
namespace HelperForChallenge
{
    public class HelperForChallenge : Mod, IGlobalSettings<GlobalSettings>, ICustomMenuMod /*, ILocalSettings<SavePresetEquipments>*/
    {

        //private ListSavePreset _savePreset;
        public static GlobalSettings settings { get; set; } = new GlobalSettings();

        public bool ToggleButtonInsideMenu => throw new NotImplementedException();

        private SavePresetEquipments _prevPlayerData;
        public HelperForChallenge() : base(ModInfo.Name) { }
        public override void Initialize()
        {
            base.Initialize();
            ModHooks.HeroUpdateHook += OnHeroUpdate;
            //ModHooks.AfterSavegameLoadHook += OnAfterSavegameLoad;
            //Modding.Logger.Log("INIT _savePreset");

            if (settings.presetEquipments == null)
            {
                SetDefultPresets();
            }
            Modding.Logger.Log("INIT _savePreset");

        }

        //private void OnAfterSavegameLoad(SaveGameData data)
        //{
        //    if (_prevPlayerData == null)
        //    {
        //        _prevPlayerData = ManagerResurse.GetPlayerData();

        //    }
        //    ManagerResurse.SetPreset(_prevPlayerData);
        //}

        public void OnLoadGlobal(GlobalSettings s)
        {
            try
            {

                if (s == null)
                {
                    SetDefultPresets();
                    ResetKeyBinds();
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
        //public void OnLoadLocal(SavePresetEquipments s)
        //{
        //    try
        //    {
        //        if (s == null) return;
        //        _prevPlayerData = s;
        //    }
        //    catch (Exception ex)
        //    {
        //        Modding.Logger.LogError(ex.ToString());
        //    }
        //}

        //public SavePresetEquipments OnSaveLocal()
        //{
        //    Modding.Logger.Log("Save _prevPlayerData");

        //    return _prevPlayerData;
        //}

        private void OnHeroUpdate()
        {
            foreach (var item in settings.binds)
            {
                if (Input.GetKeyDown(item.Value))
                {
                    ManagerResurse.SetPreset(settings.presetEquipments[item.Key]);
                }
            }

        }

        public static void SetDefultPresets()
        {

            //savePresetEquipment;
            Modding.Logger.Log("Start saveStandartPreset");

            //SavePresetEquipments standartPreset = new SavePresetEquipments();
            Modding.Logger.Log("Start Load savePresetEquipment");

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

        }

        public static void ResetKeyBinds()
        {
            settings.binds.Clear();

            settings.binds.Add("04", KeyCode.Alpha1);
            settings.binds.Add("0w", KeyCode.Alpha2);
            settings.binds.Add("Itemless", KeyCode.Alpha3);
            settings.binds.Add("NMA", KeyCode.Alpha4);
            settings.binds.Add("NNA", KeyCode.Alpha5);
            settings.binds.Add("NailOnly", KeyCode.Alpha6);

            settings.binds.Add("FullSave", KeyCode.Alpha0);
        }
        public override string GetVersion() => ModInfo.Version;

        public MenuScreen GetMenuScreen(MenuScreen modListMenu, ModToggleDelegates? toggleDelegates) =>
            ModMenu.CreateMenuScreen(modListMenu).Build();
    }
}