using Satchel.BetterMenus;
using System;
using System.Linq;


namespace GearSwitcher.ModMenu
{
    internal class PresetConfigurationMenu
    {
        private static Menu MenuRef;
        private static MenuScreen MenuScreenRef;

        internal static Menu PrepareMenu(SavePresetEquipments preset)
        {

            var menu = new Menu($"preset:{preset.Name}", new Element[]{

               //new HorizontalOption(
               //     "Max health", "",
               //     ["1","2","3","4","5","6","7","8","9"],
               //     (setting) => { preset.MaxHealth = setting+1; },
               //     () => preset.MaxHealth-1,
               //     Id:"Max health"),

               new CustomSlider(
                    name: "Max Health",
                    storeValue: val =>
                    {
                       preset.MaxHealth = (int) val;
                    },
                    loadValue: () =>  preset.MaxHealth,
                    minValue: 1,
                    maxValue: 9,
                    wholeNumbers: true
                    ),

               new HorizontalOption(
                    "Soul Vessels", "",
                    ["0","1","2","3"],
                    (setting) => { preset.SoulVessels = (setting); },
                    () => preset.SoulVessels,
                    Id:"MaxSoul"),

               //new HorizontalOption(
               //     "Nail Damage", "",
               //     ["5","9","13","17","21"],
               //     (setting) => { preset.NailDamage = (setting+1)*4+1; },
               //     () => (preset.NailDamage-1)/4-1,
               //     Id:"NailDamage"),

               new CustomSlider(
                    name: "Nail Damage",
                    storeValue: val =>
                    {
                       preset.NailDamage = (int) val;
                    },
                    loadValue: () =>  preset.NailDamage,
                    minValue: 1,
                    maxValue: 21,
                    wholeNumbers: true
                    ),

               //new HorizontalOption(
               //     "Charm Notches", "",
               //     ["3","4","5","6","7","8","9","10","11"],
               //     (setting) => { preset.CharmSlots = setting+3; },
               //     () => preset.CharmSlots-3,
               //     Id:"CharmSlots"),

                new CustomSlider(
                    name: "Charm Notches",
                    storeValue: val =>
                    {
                       preset.CharmSlots = (int) val;
                    },
                    loadValue: () =>  preset.CharmSlots,
                    minValue: 3,
                    maxValue: 11,
                    wholeNumbers: true
                    ),

               new TextPanel(""),

               new HorizontalOption(
                    "All Movement", "",
                    ["False","True"],
                    (setting) => {
                        preset.HasAllMoveAbilities = setting == 1;
                    },
                    () => preset.HasAllMoveAbilities?1:0,
                    Id:"HasAllMoveAbilities"),

               new TextPanel("Movement"),

               new HorizontalOption(
                    "Ismas Tear", "",
                    ["False","True"],
                    (setting) => { preset.HasMoveAbilities["AcidArmour"] = setting == 1; },
                    () => preset.HasMoveAbilities["AcidArmour"]?1:0,
                    Id:"AcidArmour"),

               new HorizontalOption(
                    "Mothwing Cloak", "",
                    ["False","True"],
                    (setting) => { preset.HasMoveAbilities["Dash"] = setting == 1; },
                    () => preset.HasMoveAbilities["Dash"]?1:0,
                    Id:"Dash"),

               new HorizontalOption(
                    "Mantis Claw", "",
                    ["False","True"],
                    (setting) => { preset.HasMoveAbilities["Walljump"] = setting == 1; },
                    () => preset.HasMoveAbilities["Walljump"]?1:0,
                    Id:"Walljump"),

               new HorizontalOption(
                    "Crystal Heart", "",
                    ["False","True"],
                    (setting) => { preset.HasMoveAbilities["SuperDash"] = setting == 1; },
                    () => preset.HasMoveAbilities["SuperDash"]?1:0,
                    Id:"SuperDash"),

               new HorizontalOption(
                    "Shade Cloak", "",
                    ["False","True"],
                    (setting) => { preset.HasMoveAbilities["ShadowDash"] = setting == 1; },
                    () => preset.HasMoveAbilities["ShadowDash"]?1:0,
                    Id:"ShadowDash"),

               new HorizontalOption(
                    "Monarch Wings", "",
                    ["False","True"],
                    (setting) => { preset.HasMoveAbilities["DoubleJump"] = setting == 1; },
                    () => preset.HasMoveAbilities["DoubleJump"]?1:0,
                    Id:"DoubleJump"),

               new TextPanel(""),


               new HorizontalOption(
                    "All Spells Level", "",
                    ["0","1","2"],
                    (setting) => { preset.AllSpelsLvl = setting; },
                    () => preset.AllSpelsLvl,
                    Id:"AllSpelsLvl"),

               new TextPanel("Spells Level"),

               new HorizontalOption(
                    "Fireball", "",
                    ["0","1","2"],
                    (setting) => { preset.SpelsLvl["fireballLevel"] = setting; },
                    () => preset.SpelsLvl["fireballLevel"],
                    Id:"fireballLevel"),

               new HorizontalOption(
                    "Quake", "",
                    ["0","1","2"],
                    (setting) => { preset.SpelsLvl["quakeLevel"] = setting; },
                    () => preset.SpelsLvl["quakeLevel"],
                    Id:"quakeLevel"),

               new HorizontalOption(
                    "Scream", "",
                    ["0","1","2"],
                    (setting) => { preset.SpelsLvl["screamLevel"] = setting; },
                    () => preset.SpelsLvl["screamLevel"],
                    Id:"screamLevel"),

               new TextPanel(""),

               new HorizontalOption(
                    "All Nail Arts", "",
                    ["False","True"],
                    (setting) => { preset.HasAllNailArts = setting == 1; },
                    () => preset.HasAllNailArts?1:0,
                    Id:"HasAllNailArts"),

               new TextPanel("Nail Arts"),

               new HorizontalOption(
                    "Cyclone", "",
                    ["False","True"],
                    (setting) => { preset.HasNailArts["hasCyclone"] = setting == 1; },
                    () => preset.HasNailArts["hasCyclone"]?1:0,
                    Id:"hasCyclone"),

               new HorizontalOption(
                    "DashSlash", "",
                    ["False","True"],
                    (setting) => { preset.HasNailArts["hasDashSlash"] = setting == 1; },
                    () => preset.HasNailArts["hasDashSlash"]?1:0,
                    Id:"hasDashSlash"),

               new HorizontalOption(
                    "GreatSlash", "",
                    ["False","True"],
                    (setting) => { preset.HasNailArts["hasUpwardSlash"] = setting == 1; },
                    () => preset.HasNailArts["hasUpwardSlash"]?1:0,
                    Id:"hasUpwardSlash"),

               new TextPanel(""),

               new HorizontalOption(
                    "Dream Nail Level", "",
                    ["0","1","2","3"],
                    (setting) => { preset.LvlDreamNail = setting; },
                    () => preset.LvlDreamNail,
                    Id:"LvlDreamNail"),

               new TextPanel(""),

               new HorizontalOption(
                    "All Bindings", "",
                    ["False","True"],
                    (setting) => { preset.HasAllBindings = setting == 1; },
                    () => preset.HasAllBindings?1:0,
                    Id:"HasAllNailArts"),

               new TextPanel("Bindings"),

               new HorizontalOption(
                    "CharmBinding", "",
                    ["False","True"],
                    (setting) => { preset.Bindings["CharmsBinding"] = setting == 1; },
                    () => preset.Bindings["CharmsBinding"]?1:0,
                    Id:"CharmsBinding"),

               new HorizontalOption(
                    "NailBinding", "",
                    ["False","True"],
                    (setting) => { preset.Bindings["NailBinding"] = setting == 1; },
                    () => preset.Bindings["NailBinding"]?1:0,
                    Id:"NailBinding"),

               new HorizontalOption(
                    "ShellBinding", "",
                    ["False","True"],
                    (setting) => { preset.Bindings["ShellBinding"] = setting == 1; },
                    () => preset.Bindings["ShellBinding"]?1:0,
                    Id:"ShellBinding"),

               new HorizontalOption(
                    "SoulBinding", "",
                    ["False","True"],
                    (setting) => { preset.Bindings["SoulBinding"] = setting == 1; },
                    () => preset.Bindings["SoulBinding"]?1:0,
                    Id:"SoulBinding"),


            });
            return menu;
        }

        internal static MenuScreen GetMenu(MenuScreen lastMenu, SavePresetEquipments preset)
        {
                MenuRef = PrepareMenu(preset);
                MenuScreenRef = MenuRef.GetMenuScreen(lastMenu);
            return MenuScreenRef;
        }

    }
}

