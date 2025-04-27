using HutongGames.PlayMaker.Actions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToggleableBindings;
namespace HelperForChallenge
{
    internal static class ManagerResurse
    {
        public static void SetPreset(SavePresetEquipments savePreset)
        {

            SetHealth(savePreset.MaxHealth);
            SetVessel(savePreset.MaxMP);
            UIUpdate.Update();

            SetNailDamage(savePreset.NailDamage);
            SetCharmSlot(savePreset.CharmSlots);
            SetMoveAbilities(savePreset.HasMoveAbilities, savePreset.HasAllMoveAbilities);
            SetLvlSpels(savePreset.SpelsLvl, savePreset.AllSpelsLvl);
            SetNailArts(savePreset.HasNailArts, savePreset.HasAllNailArts);
            SetLvlDreamNail(savePreset.LvlDreamNail);
            SetBindings(savePreset.Bindings, savePreset.HasAllBindings);
        }
        public static void SetHealth(int MaxHealth)
        {
            if (MaxHealth < 1) MaxHealth = 1;
            if (MaxHealth > 9) MaxHealth = 9;

            if (PlayerData.instance.maxHealth <= MaxHealth)
            {
                PlayerData.instance.maxHealth -= PlayerData.instance.maxHealth - MaxHealth;
                PlayerData.instance.maxHealthBase -= PlayerData.instance.maxHealth - MaxHealth;
                PlayerData.instance.MaxHealth();
            }
            else
            {
                PlayerData.instance.maxHealth -= PlayerData.instance.maxHealth - MaxHealth;
                PlayerData.instance.maxHealthBase -= PlayerData.instance.maxHealth - MaxHealth;
                PlayerData.instance.MaxHealth();

            }
        }

        public static void SetVessel(int MaxMP)
        {
            if (MaxMP < 99) MaxMP = 99;
            if (MaxMP > 198) MaxMP = 198;

            int MaxMPReserve = ((MaxMP - 99) / 33) * 33;

            Modding.Logger.Log(MaxMPReserve);
            if (PlayerData.instance.MPReserveMax < MaxMPReserve)
            {
                HeroController.instance.AddToMaxMPReserve(MaxMPReserve - PlayerData.instance.MPReserveMax);
            }
            else
            {
                PlayerData.instance.MPReserveMax = MaxMPReserve;
            }
            //HeroController.instance.ClearMP();
        }

        public static void SetNailDamage(int Damage)
        {
            if (Damage < 5) Damage = 5;
            if (Damage > 21) Damage = 21;
            Damage = ((Damage - 1) / 4 * 4) + 1;
            PlayerData.instance.nailDamage = Damage;
            PlayerData.instance.nailSmithUpgrades = (Damage - 1) / 4 - 1;
        }

        public static void SetCharmSlot(int CharmSlots)
        {
            if (CharmSlots < 3) CharmSlots = 3;
            if (CharmSlots < 11) CharmSlots = 11;

            PlayerData.instance.charmSlots = CharmSlots;
        }

        public static void SetMoveAbilities(Dictionary<string, bool> MoveAbilities, bool HasAllMoveAbilities = false)
        {
            foreach (var MA in MoveAbilities)
            {
                PlayerData.instance.SetBool(MA.Key, MA.Value || HasAllMoveAbilities);
            }
        }

        public static void SetLvlSpels(Dictionary<string, int> LvlSpels, int LvlAllSpels = -1)
        {
            if (LvlAllSpels > 2) LvlAllSpels = 2;

            foreach (var spells in LvlSpels)
            {
                PlayerData.instance.SetInt(spells.Key, LvlAllSpels < 0 ? spells.Value : LvlAllSpels);
            }
        }
        public static void SetNailArts(Dictionary<string, bool> NailArts, bool HasAllNailArts = false)
        {
            PlayerData.instance.hasNailArt = false;
            PlayerData.instance.hasAllNailArts = false;
            if (HasAllNailArts == true)
            {
                PlayerData.instance.hasNailArt = true;
                PlayerData.instance.hasAllNailArts = true;
            }
            foreach (var NA in NailArts)
            {
                if (HasAllNailArts == true) PlayerData.instance.hasAllNailArts = true;

                PlayerData.instance.SetBool(NA.Key, NA.Value || HasAllNailArts);
            }
        }
        public static void SetLvlDreamNail(int LvlDreamNail)
        {
            if (LvlDreamNail < 0) LvlDreamNail = 0;
            if (LvlDreamNail > 3) LvlDreamNail = 3;

            if (LvlDreamNail == 0)
            {
                PlayerData.instance.hasDreamNail = false;
                PlayerData.instance.hasDreamGate = false;
                PlayerData.instance.dreamNailUpgraded = false;
            }
            if (LvlDreamNail == 1)
            {
                PlayerData.instance.hasDreamNail = true;
                PlayerData.instance.hasDreamGate = false;
                PlayerData.instance.dreamNailUpgraded = false;
            }
            if (LvlDreamNail == 2)
            {
                PlayerData.instance.hasDreamNail = true;
                PlayerData.instance.hasDreamGate = true;
                PlayerData.instance.dreamNailUpgraded = false;
            }
            if (LvlDreamNail == 3)
            {
                PlayerData.instance.hasDreamNail = true;
                PlayerData.instance.hasDreamGate = true;
                PlayerData.instance.dreamNailUpgraded = true;
            }
        }

        public static void SetBindings(Dictionary<string, bool> Bindings, bool HasAllBindings = false)
        {

            string IDBinding = "ToggleableBindings::";


            foreach (var B in Bindings)
            {
                Modding.Logger.Log(IDBinding + B.Key);
                if (B.Value || HasAllBindings)
                    BindingManager.ApplyBinding(IDBinding + B.Key);
                else
                    BindingManager.RestoreBinding(IDBinding + B.Key);
            }
        }

        public static SavePresetEquipments GetPlayerData()
        {
            SavePresetEquipments value = new();

            value.MaxHealth = PlayerData.instance.maxHealth;
            value.NailDamage = PlayerData.instance.nailDamage;
            value.CharmSlots = PlayerData.instance.charmSlots;
            foreach (var MA in value.HasMoveAbilities)
            {
                value.HasMoveAbilities[MA.Key] = PlayerData.instance.GetBool(MA.Key);
            }
            foreach (var spells in value.SpelsLvl)
            {
                value.SpelsLvl[spells.Key] = PlayerData.instance.GetInt(spells.Key);
            }
            foreach (var NA in value.HasNailArts)
            {
                value.HasNailArts[NA.Key] = PlayerData.instance.GetBool(NA.Key);
            }

            value.LvlDreamNail = (PlayerData.instance.hasDreamNail ? 1 : 0) + (PlayerData.instance.hasDreamGate ? 1 : 0) + (PlayerData.instance.dreamNailUpgraded ? 1 : 0);

            return value;
        }
    }
}

