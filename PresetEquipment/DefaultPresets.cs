
namespace GearSwitcher
{
    internal static class DefaultPresets
    {
        public static SavePresetEquipments FullSave()
        {
            SavePresetEquipments value = new();

            value.Name = "FullSave";
            value.MaxHealth = 9;
            value.MaxMP = 198;
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

            value.Name = "O4";
            value.MaxHealth = 9;
            value.MaxMP = 198;
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

            value.Name = "Ow";
            value.MaxHealth = 9;
            value.MaxMP = 198;
            value.NailDamage = 5;
            value.CharmSlots = 11;
            value.HasAllMoveAbilities = true;
            value.AllSpelsLvl = 1;
            value.HasAllNailArts = true;
            value.LvlDreamNail = 3;

            return value;
        }

        public static SavePresetEquipments ItemLess()
        {
            SavePresetEquipments value = new();

            value.Name = "ItemLess";

            return value;
        }

        public static SavePresetEquipments NMA()
        {
            SavePresetEquipments value = new();

            value.Name = "NMA";
            value.MaxHealth = 9;
            value.MaxMP = 198;
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
            value.MaxMP = 198;
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
            value.MaxMP = 198;
            value.NailDamage = 21;
            value.CharmSlots = 11;
            value.AllSpelsLvl = 0;
            value.HasAllMoveAbilities = true;
            value.LvlDreamNail = 3;

            return value;
        }

    }
}
