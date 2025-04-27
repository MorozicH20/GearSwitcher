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
    public class HelperForChallenge : Mod, IGlobalSettings<List<SavePresetEquipments>>, ILocalSettings<SavePresetEquipments>
    {

        private ListSavePreset _savePreset;
        private SavePresetEquipments _prevPlayerData;
        public HelperForChallenge() : base(ModInfo.Name) { }
        public override void Initialize()
        {
            base.Initialize();
            ModHooks.HeroUpdateHook += OnHeroUpdate;
            ModHooks.AfterSavegameLoadHook += OnAfterSavegameLoad;
            //Modding.Logger.Log("INIT _savePreset");

            if (_savePreset == null)
            {
                _savePreset = new();
                _savePreset.SetDefult();
            }
            Modding.Logger.Log("INIT _savePreset");

        }

        private void OnAfterSavegameLoad(SaveGameData data)
        {
            if (_prevPlayerData == null)
            {
                _prevPlayerData = ManagerResurse.GetPlayerData();

            }
            ManagerResurse.SetPreset(_prevPlayerData);
        }

        public void OnLoadGlobal(List<SavePresetEquipments> s)
        {
            try
            {
                _savePreset = new();

                if (s == null)
                {
                    _savePreset.SetDefult();
                    Modding.Logger.Log("INIT/Load _savePreset");

                    return;
                }
                Modding.Logger.Log("Load _savePreset");

                _savePreset.savePresetEquipment = s;

            }
            catch (Exception ex)
            {
                Modding.Logger.LogError(ex.ToString());
            }

        }

        List<SavePresetEquipments> IGlobalSettings<List<SavePresetEquipments>>.OnSaveGlobal()
        {
            if (_savePreset.savePresetEquipment == null)
            {
                _savePreset.SetDefult();
                Modding.Logger.Log("INIT _savePreset");

            }
            Modding.Logger.Log("Save _savePreset");

            return _savePreset.savePresetEquipment;
        }
        public void OnLoadLocal(SavePresetEquipments s)
        {
            try
            {
                if (s == null) return;
                _prevPlayerData = s;
            }
            catch (Exception ex)
            {
                Modding.Logger.LogError(ex.ToString());
            }
        }

        public SavePresetEquipments OnSaveLocal()
        {
            Modding.Logger.Log("Save _prevPlayerData");

            return _prevPlayerData;
        }

        private void OnHeroUpdate()
        {
            if (Input.GetKeyDown(KeyCode.Alpha1))
            {
                ManagerResurse.SetPreset(_savePreset.savePresetEquipment[0]);
            }

            if (Input.GetKeyDown(KeyCode.Alpha2))
            {
                ManagerResurse.SetPreset(_savePreset.savePresetEquipment[1]);
            }

            if (Input.GetKeyDown(KeyCode.Alpha3))
            {
                ManagerResurse.SetPreset(_savePreset.savePresetEquipment[2]);
            }

            if (Input.GetKeyDown(KeyCode.Alpha4))
            {
                ManagerResurse.SetPreset(_savePreset.savePresetEquipment[3]);
            }

        }

        public override string GetVersion() => ModInfo.Version;

    }
}