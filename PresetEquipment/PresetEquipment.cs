using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Runtime.CompilerServices;
using ToggleableBindings;
using Modding;
using static GamepadVibrationMixer.GamepadVibrationEmission;
using GearSwitcher;
using Newtonsoft.Json;


namespace GearSwitcher
{
    //public class PresetEquipment
    //{
    //    public int maxHealth;
    //    public int maxMP;
    //    public int nailDamage;
    //    public int charmSlots;
    //    public bool hasAcidArmour;
    //    public bool hasDash;
    //    public bool hasWalljump;
    //    public bool hasSuperDash;
    //    public bool hasShadowDash;
    //    public bool hasDoubleJump;
    //    public int fireballLevel;
    //    public int quakeLevel;
    //    public int screamLevel;
    //    public bool hasCyclone;
    //    public bool hasDashSlash;
    //    public bool hasUpwardSlash;
    //    public bool hasDreamNail;



    //    public void ReadData(PlayerData PD)
    //    {
    //        this.maxHealth = PD.maxHealth;
    //        this.nailDamage = PD.nailDamage;
    //        this.charmSlots = PD.charmSlots;
    //        this.hasAcidArmour = PD.hasAcidArmour;
    //        this.hasDash = PD.hasDash;
    //        this.hasWalljump = PD.hasWalljump;
    //        this.hasSuperDash = PD.hasSuperDash;
    //        this.hasShadowDash = PD.hasShadowDash;
    //        this.hasDoubleJump = PD.hasDoubleJump;
    //        this.fireballLevel = PD.fireballLevel;
    //        this.quakeLevel = PD.quakeLevel;
    //        this.screamLevel = PD.screamLevel;
    //        this.hasCyclone = PD.hasCyclone;
    //        this.hasDashSlash = PD.hasDashSlash;
    //        this.hasUpwardSlash = PD.hasUpwardSlash;
    //        this.hasDreamNail = PD.hasDreamNail;
    //    }
    //    public PlayerData ApplyPreset(PlayerData PD)
    //    {
    //        PD.maxHealth = this.maxHealth;
    //        PD.nailDamage = this.nailDamage;
    //        PD.charmSlots = this.charmSlots;
    //        PD.hasAcidArmour = this.hasAcidArmour;
    //        PD.hasDash = this.hasDash;
    //        PD.hasWalljump = this.hasWalljump;
    //        PD.hasSuperDash = this.hasSuperDash;
    //        PD.hasShadowDash = this.hasShadowDash;
    //        PD.hasDoubleJump = this.hasDoubleJump;
    //        PD.fireballLevel = this.fireballLevel;
    //        PD.quakeLevel = this.quakeLevel;
    //        PD.screamLevel = this.screamLevel;
    //        PD.hasCyclone = this.hasCyclone;
    //        PD.hasDashSlash = this.hasDashSlash;
    //        PD.hasUpwardSlash = this.hasUpwardSlash;
    //        PD.hasDreamNail = this.hasDreamNail;

    //        return PD;
    //    }
    //    public void ApplyPreset(SavePresetEquipments savePreset)
    //    {

    //        ManagerResurse.SetPreset(savePreset);

    //        //UIUpdate.Update();

    //    }
    //}
    public class SavePresetEquipments
    {
        public string Name = "newGame";

        public int MaxHealth = 5;
        public int MaxMP = 99;
        public int NailDamage = 5;
        public int CharmSlots = 3;

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
        //public bool hasAcidArmour = true;
        //public bool hasDash = true;
        //public bool hasWalljump = true;
        //public bool hasSuperDash = true;
        //public bool hasShadowDash = true;
        //public bool hasDoubleJump = true;
        public int AllSpelsLvl;
        public Dictionary<string, int> SpelsLvl = new()
        {
            { "fireballLevel", 0 },
            { "quakeLevel", 0 },
            { "screamLevel", 0 }

        };
        //public int fireballLevel = 2;
        //public int quakeLevel = 2;
        //public int screamLevel = 2;

        public bool HasAllNailArts;

        public Dictionary<string, bool> HasNailArts = new()
        {
            { "hasCyclone", false },
            { "hasDashSlash", false },
            { "hasUpwardSlash", false },

        };
        //public bool hasCyclone = true;
        //public bool hasDashSlash = true;
        //public bool hasUpwardSlash = true;
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
