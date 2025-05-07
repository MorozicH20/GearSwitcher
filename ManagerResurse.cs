using System;
using System.Collections.Generic;
using System.Linq;
using ToggleableBindings;
namespace GearSwitcher
{
    internal static class ManagerResurse
    {
        public static void SetPreset(SavePresetEquipments savePreset)
        {
            GearSwitcher.localSettings.LastPreset = savePreset.Name;

            List<int> _LastEquippedCharms = PlayerData.instance.equippedCharms.ToList();


            SetBindings(savePreset.Bindings, savePreset.HasAllBindings);

            RemoveCharms();

            SetHealth(savePreset.MaxHealth);
            SetVessel(savePreset.SoulVessels);
            SetCharmSlot(savePreset.CharmSlots);

            if (GearSwitcher.settings.isSaveСollectionsCharms)
            {
                if (savePreset.EquippedCharms != null && savePreset.EquippedCharms.Count > 0)
                    EquipCharms(savePreset.EquippedCharms);
            }
            else
                EquipCharms(_LastEquippedCharms);



            SetNailDamage(savePreset.NailDamage);
            SetMoveAbilities(savePreset.HasMoveAbilities, savePreset.HasAllMoveAbilities);
            SetLvlSpels(savePreset.SpelsLvl, savePreset.AllSpelsLvl);
            SetNailArts(savePreset.HasNailArts, savePreset.HasAllNailArts);
            SetLvlDreamNail(savePreset.LvlDreamNail);

            UIUpdate.Update();
        }
        public static void SetHealth(int MaxHealth)
        {
            if (MaxHealth < 1) MaxHealth = 1;
            if (MaxHealth > 9) MaxHealth = 9;

            PlayerData.instance.maxHealth = MaxHealth;
            PlayerData.instance.maxHealthBase = MaxHealth;
            PlayerData.instance.prevHealth = MaxHealth;
            PlayerData.instance.MaxHealth();
        }

        public static void SetVessel(int Vessels)
        {
            if (Vessels < 0) Vessels = 0;
            if (Vessels > 3) Vessels = 3;

            if (PlayerData.instance.MPReserveMax < Vessels * 33)
            {
                HeroController.instance.AddToMaxMPReserve(Vessels * 33 - PlayerData.instance.MPReserveMax);
            }
            else
            {
                PlayerData.instance.MPReserveMax = Vessels * 33;
            }
        }

        public static void SetNailDamage(int Damage)
        {
            if (Damage < 1) Damage = 1;
            if (Damage > 21) Damage = 21;
            PlayerData.instance.nailDamage = Damage;
            PlayerData.instance.nailSmithUpgrades = (Damage - 1) / 4 - 1;
            PlayMakerFSM.BroadcastEvent("UPDATE NAIL DAMAGE");
        }

        public static void SetCharmSlot(int CharmSlots)
        {
            if (CharmSlots < 3) CharmSlots = 3;
            if (CharmSlots > 11) CharmSlots = 11;

            PlayerData.instance.charmSlots = CharmSlots;
        }

        public static void SetMoveAbilities(Dictionary<string, bool> MoveAbilities, bool HasAllMoveAbilities = false)
        {
            foreach (var MA in MoveAbilities)
            {
                PlayerData.instance.SetBool("has" + MA.Key, MA.Value || HasAllMoveAbilities);
                PlayerData.instance.SetBool("can" + MA.Key, MA.Value || HasAllMoveAbilities);

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
                if (B.Value || HasAllBindings)
                    BindingManager.ApplyBinding(IDBinding + B.Key);
                else
                    BindingManager.RestoreBinding(IDBinding + B.Key);
            }
        }

        internal static void RemoveCharms()
        {
            List<int> equippedCharms = PlayerData.instance.equippedCharms.ToList();
            foreach (int idCharm in equippedCharms)
            {
            if (PlayerData.instance.royalCharmState == 4 && idCharm==36) continue;
                PlayerData.instance.SetBoolInternal("equippedCharm_" + idCharm, false);
                PlayerData.instance.UnequipCharm(idCharm);
            }

            PlayerData.instance.overcharmed = false;

            PlayerData.instance.CalculateNotchesUsed();
            HeroController.instance.CharmUpdate();

        }
        internal static void EquipCharms(List<int> Charms)
        {
            var usedCharmSlots = 0;
            for (int i = 0; i < Charms.Count; i++)
            {
                int idCharm = Charms[i];
                if (!PlayerData.instance.GetBoolInternal("equippedCharm_" + idCharm))
                {
                    PlayerData.instance.SetBoolInternal("equippedCharm_" + idCharm, true);
                    PlayerData.instance.EquipCharm(idCharm);

                    usedCharmSlots += PlayerData.instance.GetInt("charmCost_" + idCharm);
                }


                if (PlayerData.instance.charmSlots <= usedCharmSlots)
                {
                    if (i < Charms.Count - 1) RemoveCharms();
                    break;
                }
            }


            if (PlayerData.instance.charmSlots < usedCharmSlots)
            {
                PlayerData.instance.charmSlotsFilled = usedCharmSlots;
                PlayerData.instance.overcharmed = true;
            }
            PlayerData.instance.CalculateNotchesUsed();
            HeroController.instance.CharmUpdate();

        }
        internal static void MakeFreeCharms(bool isFree)
        {

            PlayerData.instance.SetInt("charmCost_" + 1, 1 * (isFree ? 0 : 1));
            PlayerData.instance.SetInt("charmCost_" + 2, 1 * (isFree ? 0 : 1));
            PlayerData.instance.SetInt("charmCost_" + 3, 1 * (isFree ? 0 : 1));
            PlayerData.instance.SetInt("charmCost_" + 4, 2 * (isFree ? 0 : 1));
            PlayerData.instance.SetInt("charmCost_" + 5, 2 * (isFree ? 0 : 1));
            PlayerData.instance.SetInt("charmCost_" + 6, 2 * (isFree ? 0 : 1));
            PlayerData.instance.SetInt("charmCost_" + 7, 3 * (isFree ? 0 : 1));
            PlayerData.instance.SetInt("charmCost_" + 8, 2 * (isFree ? 0 : 1));
            PlayerData.instance.SetInt("charmCost_" + 9, 3 * (isFree ? 0 : 1));
            PlayerData.instance.SetInt("charmCost_" + 10, 1 * (isFree ? 0 : 1));
            PlayerData.instance.SetInt("charmCost_" + 11, 3 * (isFree ? 0 : 1));
            PlayerData.instance.SetInt("charmCost_" + 12, 1 * (isFree ? 0 : 1));
            PlayerData.instance.SetInt("charmCost_" + 13, 3 * (isFree ? 0 : 1));
            PlayerData.instance.SetInt("charmCost_" + 14, 1 * (isFree ? 0 : 1));
            PlayerData.instance.SetInt("charmCost_" + 15, 2 * (isFree ? 0 : 1));
            PlayerData.instance.SetInt("charmCost_" + 16, 2 * (isFree ? 0 : 1));
            PlayerData.instance.SetInt("charmCost_" + 17, 1 * (isFree ? 0 : 1));
            PlayerData.instance.SetInt("charmCost_" + 18, 2 * (isFree ? 0 : 1));
            PlayerData.instance.SetInt("charmCost_" + 19, 3 * (isFree ? 0 : 1));
            PlayerData.instance.SetInt("charmCost_" + 20, 2 * (isFree ? 0 : 1));
            PlayerData.instance.SetInt("charmCost_" + 21, 4 * (isFree ? 0 : 1));
            PlayerData.instance.SetInt("charmCost_" + 22, 2 * (isFree ? 0 : 1));
            PlayerData.instance.SetInt("charmCost_" + 23, 2 * (isFree ? 0 : 1));
            PlayerData.instance.SetInt("charmCost_" + 24, 2 * (isFree ? 0 : 1));
            PlayerData.instance.SetInt("charmCost_" + 25, 3 * (isFree ? 0 : 1));
            PlayerData.instance.SetInt("charmCost_" + 26, 1 * (isFree ? 0 : 1));
            PlayerData.instance.SetInt("charmCost_" + 27, 4 * (isFree ? 0 : 1));
            PlayerData.instance.SetInt("charmCost_" + 28, 2 * (isFree ? 0 : 1));
            PlayerData.instance.SetInt("charmCost_" + 29, 4 * (isFree ? 0 : 1));
            PlayerData.instance.SetInt("charmCost_" + 30, 1 * (isFree ? 0 : 1));
            PlayerData.instance.SetInt("charmCost_" + 31, 2 * (isFree ? 0 : 1));
            PlayerData.instance.SetInt("charmCost_" + 32, 3 * (isFree ? 0 : 1));
            PlayerData.instance.SetInt("charmCost_" + 33, 2 * (isFree ? 0 : 1));
            PlayerData.instance.SetInt("charmCost_" + 34, 4 * (isFree ? 0 : 1));
            PlayerData.instance.SetInt("charmCost_" + 35, 3 * (isFree ? 0 : 1));

            if (PlayerData.instance.royalCharmState == 4)
                PlayerData.instance.SetInt("charmCost_" + 36, 0 * (isFree ? 0 : 1));
            else
                PlayerData.instance.SetInt("charmCost_" + 36, 5 * (isFree ? 0 : 1));

            PlayerData.instance.SetInt("charmCost_" + 37, 1 * (isFree ? 0 : 1));
            PlayerData.instance.SetInt("charmCost_" + 38, 3 * (isFree ? 0 : 1));
            PlayerData.instance.SetInt("charmCost_" + 39, 2 * (isFree ? 0 : 1));
            PlayerData.instance.SetInt("charmCost_" + 40, 2 * (isFree ? 0 : 1));

        }
    }
}

