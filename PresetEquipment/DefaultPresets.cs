﻿
namespace GearSwitcher
{
    internal static class DefaultPresets
    {
        public static SavePresetEquipments FullGear()
        {
            SavePresetEquipments value = new();

            value.Name = "FullGear";
            value.MaxHealth = 9;
            value.SoulVessels = 3;
            value.NailDamage = 21;
            value.CharmSlots = 11;
            value.HasAllMoveAbilities = true;
            value.AllSpelsLvl = 2;
            value.HasAllNailArts = true;
            value.LvlDreamNail = 3;
            return value;
        }
        public static SavePresetEquipments O4()
        {
            SavePresetEquipments value = new();

            value.Name = "04";
            value.MaxHealth = 9;
            value.SoulVessels = 3;
            value.NailDamage = 5;
            value.CharmSlots = 11;
            value.HasAllMoveAbilities = true;
            value.AllSpelsLvl = 1;
            value.HasAllNailArts = true;
            value.LvlDreamNail = 3;
            value.HasAllBindings = true;
            return value;
        }
        public static SavePresetEquipments Ow()
        {
            SavePresetEquipments value = new();

            value.Name = "0w";
            value.MaxHealth = 9;
            value.SoulVessels = 3;
            value.NailDamage = 5;
            value.CharmSlots = 11;
            value.HasAllMoveAbilities = true;
            value.AllSpelsLvl = 1;
            value.HasAllNailArts = true;
            value.LvlDreamNail = 3;

            return value;
        }

        public static SavePresetEquipments Itemless()
        {
            SavePresetEquipments value = new();

            value.Name = "Itemless";

            return value;
        }

        public static SavePresetEquipments NMA()
        {
            SavePresetEquipments value = new();

            value.Name = "NMA";
            value.MaxHealth = 9;
            value.SoulVessels = 3;
            value.NailDamage = 21;
            value.CharmSlots = 11;

            value.AllSpelsLvl = 2;
            value.HasAllNailArts = true;
            value.LvlDreamNail = 3;

            return value;
        }

        public static SavePresetEquipments NNA()
        {
            SavePresetEquipments value = new();

            value.Name = "NNA";
            value.MaxHealth = 9;
            value.SoulVessels = 3;
            value.NailDamage = 21;
            value.CharmSlots = 11;
            value.AllSpelsLvl = 2;
            value.HasAllMoveAbilities = true;
            value.LvlDreamNail = 3;

            return value;
        }
        public static SavePresetEquipments NailOnly()
        {

            SavePresetEquipments value = new();

            value.Name = "NailOnly";
            value.MaxHealth = 9;
            value.SoulVessels = 3;
            value.NailDamage = 21;
            value.CharmSlots = 11;
            value.AllSpelsLvl = 0;
            value.HasAllMoveAbilities = true;
            value.HasAllNailArts = true;
            value.LvlDreamNail = 3;

            return value;
        }
        public static SavePresetEquipments AB()
        {

            SavePresetEquipments value = new();

            value.Name = "AB";
            value.MaxHealth = 9;
            value.SoulVessels = 3;
            value.NailDamage = 21;
            value.CharmSlots = 11;
            value.HasAllMoveAbilities = true;
            value.AllSpelsLvl = 2;
            value.HasAllNailArts = true;
            value.LvlDreamNail = 3;
            value.HasAllBindings = true;

            return value;
        }

    }
}
