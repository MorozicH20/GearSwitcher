using System.Collections.Generic;



namespace GearSwitcher
{
    public class SavePresetEquipments
    {
        public string Name = "null";

        public int MaxHealth = 5;
        public int MaxMP = 99;
        public int NailDamage = 5;
        public int CharmSlots = 3;

        public List<int> EquippedCharms = null;

        public bool HasAllMoveAbilities = false;
        public Dictionary<string, bool> HasMoveAbilities = new()
        {

            { "AcidArmour", false },
            { "Dash", false },
            { "Walljump", false },
            { "SuperDash", false },
            { "ShadowDash", false },
            { "DoubleJump", false },

        };
        public int AllSpelsLvl;
        public Dictionary<string, int> SpelsLvl = new()
        {
            { "fireballLevel", 0 },
            { "quakeLevel", 0 },
            { "screamLevel", 0 }

        };

        public bool HasAllNailArts;
        public Dictionary<string, bool> HasNailArts = new()
        {
            { "hasCyclone", false },
            { "hasDashSlash", false },
            { "hasUpwardSlash", false },

        };
        public int LvlDreamNail = 0;

        public bool HasAllBindings;

        public Dictionary<string, bool> Bindings = new()
        {
            { "CharmsBinding", false },
            { "NailBinding", false },
            { "ShellBinding", false },
            { "SoulBinding", false },

        };
    }
}
