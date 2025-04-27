# GearSwitcher - Hollow Knight Mod

## Introduction

This mod allows players to quickly switch between pre-defined gear presets in Hollow Knight. This is useful for various challenges, speedruns, or simply for experimenting with different builds on the fly.

## Dependencies

*   [ToggleableBindings] (v0.13) - https://github.com/Unordinal/HollowKnight.ToggleableBindings)

## Features

Preset Management: Save and load custom gear loadouts.
In-Game Switching: Quickly swap between presets using customizable hotkeys.
Installation
Make sure you have the Hollow Knight modding API installed (e.g., Modding API).
Place the HelperForChallenge.dll file into your Hollow Knight’s Mods folder.
Run the game.

## Configuration

The mod uses JSON files to store and manage your presets. You can customize the following settings:

Preset File: The mod will read preset data from a JSON file located in the Hollow Knight game directory (Steam: "C:\Users\User\AppData\LocalLow\Team Cherry\Hollow Knight\HelperForChallenge.GlobalSettings.json").
Hotkey Customization: (Future Feature) Configure hotkeys to switch between your presets.
Preset JSON Structure
The main configuration file is a JSON array. Each element in the array represents a preset. The configuration file is a JSON array. Each element in the array represents a preset.

for example

```json

[
  {
    "Name": "O4",
    "MaxHealth": 9,
    "MaxMP": 198,
    "NailDamage": 5,
    "CharmSlots": 11,
    "HasAllMoveAbilities": true,
    "HasMoveAbilities": {
      "hasAcidArmour": false,
      "hasDash": false,
      "hasWalljump": false,
      "hasSuperDash": false,
      "hasShadowDash": false,
      "hasDoubleJump": false
    },
    "AllSpelsLvl": 1,
    "SpelsLvl": {
      "fireballLevel": 0,
      "quakeLevel": 0,
      "screamLevel": 0
    },
    "HasAllNailArts": true,
    "HasNailArts": {
      "hasCyclone": false,
      "hasDashSlash": false,
      "hasUpwardSlash": false
    },
    "LvlDreamNail": 3,
    "HasAllBindings": true,
    "Bindings": {
      "CharmsBinding": false,
      "NailBinding": false,
      "ShellBinding": false,
      "SoulBinding": false
    }
  },
  {
    "Name": "Example Preset 2",
    "MaxHealth": 6,
    "MaxMP": 100,
    "NailDamage": 3,
    "CharmSlots": 6,
    "HasAllMoveAbilities": false,
    "HasMoveAbilities": {
      "hasAcidArmour": true,
      "hasDash": true,
      "hasWalljump": true,
      "hasSuperDash": false,
      "hasShadowDash": false,
      "hasDoubleJump": false
    },
    "AllSpelsLvl": 0,
    "SpelsLvl": {
      "fireballLevel": 0,
      "quakeLevel": 0,
      "screamLevel": 0
    },
    "HasAllNailArts": false,
    "HasNailArts": {
      "hasCyclone": true,
      "hasDashSlash": false,
      "hasUpwardSlash": false
    },
    "LvlDreamNail": 1,
    "HasAllBindings": false,
    "Bindings": {
      "CharmsBinding": false,
      "NailBinding": true,
      "ShellBinding": false,
      "SoulBinding": false
    }
  }
]
```

Name: (string) The name of the preset.
MaxHealth: (integer) Maximum health.
MaxMP: (integer) Maximum MP (Soul).
NailDamage: (integer) Nail damage level.
CharmSlots: (integer) Number of available charm slots.
HasAllMoveAbilities: (boolean) Whether all movement abilities are unlocked. If true, the HasMoveAbilities field is ignored.
HasMoveAbilities: (object) An object containing booleans for each movement ability.
hasAcidArmour: (boolean) Has acid armor.
hasDash: (boolean) Has dash.
hasWalljump: (boolean) Has wall jump.
hasSuperDash: (boolean) Has super dash.
hasShadowDash: (boolean) Has shadow dash.
hasDoubleJump: (boolean) Has double jump.
AllSpelsLvl: (integer) The level of all spells. If 1 the “SpelsLvl” is ignored.
SpelsLvl: (object) An object containing integers for each spell level.
fireballLevel: (integer) Fireball level.
quakeLevel: (integer) Quake level.
screamLevel: (integer) Scream level.
HasAllNailArts: (boolean) Whether all nail arts are unlocked. If true, the HasNailArts field is ignored.
HasNailArts: (object) An object containing booleans for each nail art.
hasCyclone: (boolean) Has cyclone slash.
hasDashSlash: (boolean) Has dash slash.
hasUpwardSlash: (boolean) Has upward slash.
LvlDreamNail: (integer) Dream nail level.
HasAllBindings: (boolean) Whether all bindings are active. If true, the Bindings field is ignored.
Bindings: (object) An object containing booleans for each binding.
CharmsBinding: (boolean) Charm binding.
NailBinding: (boolean) Nail binding.
ShellBinding: (boolean) Shell binding.
SoulBinding: (boolean) Soul binding.

## Usage

Edit a HelperForChallenge.GlobalSettings.jsonn file with your desired presets in the format shown above.
In-game, press the configured hotkeys to cycle through your presets.

## Future Features

Hotkey customization.
UI for preset management within the game.

## Test Version (v1.0.0.0-beta

This is a test version of the mod. Currently, it includes 4 pre-defined presets. You can activate these presets by pressing the 1, 2, 3, and 4 keys on your keyboard respectively during gameplay. These keys directly select the corresponding preset from the HelperForChallenge.GlobalSettings.json file.
