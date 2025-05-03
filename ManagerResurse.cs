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

            RemoveCharms();

            SetHealth(savePreset.MaxHealth);
            SetVessel(savePreset.MaxMP);
            SetCharmSlot(savePreset.CharmSlots);

            if (GearSwitcher.settings.isSaveСollectionsCharms)
            {
                if (savePreset.EquippedCharms != null && savePreset.EquippedCharms.Count > 0)
                    EquipCharms(savePreset.EquippedCharms);
            }
            else
                EquipCharms(_LastEquippedCharms);


            UIUpdate.Update();

            SetNailDamage(savePreset.NailDamage);
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

            PlayerData.instance.maxHealth = MaxHealth;
            PlayerData.instance.maxHealthBase = MaxHealth;
            PlayerData.instance.prevHealth = MaxHealth;
            PlayerData.instance.MaxHealth();

        }

        public static void SetVessel(int MaxMP)
        {
            if (MaxMP < 99) MaxMP = 99;
            if (MaxMP > 198) MaxMP = 198;

            int MaxMPReserve = ((MaxMP - 99) / 33) * 33;

            if (PlayerData.instance.MPReserveMax < MaxMPReserve)
            {
                HeroController.instance.AddToMaxMPReserve(MaxMPReserve - PlayerData.instance.MPReserveMax);
            }
            else
            {
                PlayerData.instance.MPReserveMax = MaxMPReserve;
            }
        }

        public static void SetNailDamage(int Damage)
        {
            if (Damage < 5) Damage = 5;
            if (Damage > 21) Damage = 21;
            Damage = ((Damage - 1) / 4 * 4) + 1;
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

        private static void RemoveCharms()
        {
            List<int> equippedCharms = PlayerData.instance.equippedCharms.ToList();
            foreach (int idCharm in equippedCharms)
            {
                PlayerData.instance.SetBoolInternal("equippedCharm_" + idCharm, false);
                PlayerData.instance.UnequipCharm(idCharm);
            }

            PlayerData.instance.overcharmed = false;

            PlayerData.instance.CalculateNotchesUsed();

            PlayMakerFSM.BroadcastEvent("CHARM EQUIP CHECK");
            PlayMakerFSM.BroadcastEvent("CHARM INDICATOR CHECK");
        }
        private static void EquipCharms(List<int> Charms)
        {
            var usedCharmSlots = 0;
            foreach (int idCharm in Charms)
            {
                if (PlayerData.instance.charmSlots <= usedCharmSlots) break;

                PlayerData.instance.SetBoolInternal("equippedCharm_" + idCharm, true);
                PlayerData.instance.EquipCharm(idCharm);
                usedCharmSlots += PlayerData.instance.GetInt("charmCost_" + idCharm);

            }


            if (PlayerData.instance.charmSlots < usedCharmSlots)
            {
                PlayerData.instance.charmSlotsFilled = usedCharmSlots;
                PlayerData.instance.overcharmed = true;
            }
            PlayerData.instance.CalculateNotchesUsed();

            PlayMakerFSM.BroadcastEvent("CHARM EQUIP CHECK");
            PlayMakerFSM.BroadcastEvent("CHARM INDICATOR CHECK");
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

