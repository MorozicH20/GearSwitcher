# GearSwitcher - Hollow Knight Mod

## Introduction

This mod allows players to quickly switch between pre-defined gear presets in Hollow Knight. This is useful for various challenges, speedruns, or simply for experimenting with different builds on the fly.

## Dependencies

*   [ToggleableBindings](https://github.com/Unordinal/HollowKnight.ToggleableBindings) (v0.13)

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
The main configuration file is a JSON array. Each element in the array represents a preset. The configuration file is a JSON array. consisting of two dictionaries: for binds and presets

For example

```json

{
  "binds": {
    "04": "Alpha1",
    "0w": "Alpha2",
    "Itemless": "Alpha3",
    "NMA": "Alpha4",
    "NNA": "Alpha5",
    "NailOnly": "Alpha6",
    "FullSave": "Alpha0"
  },
  "presetEquipments": {
    "FullSave": {
      "Name": "FullSave",
      "MaxHealth": 9,
      "MaxMP": 198,
      "NailDamage": 21,
      "CharmSlots": 11,
      "HasAllMoveAbilities": true,
      "HasMoveAbilities": {
        "AcidArmour": false,
        "Dash": false,
        "Walljump": false,
        "SuperDash": false,
        "ShadowDash": false,
        "DoubleJump": false
      },
      "AllSpelsLvl": 2,
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
      "HasAllBindings": false,
      "Bindings": {
        "CharmsBinding": false,
        "NailBinding": false,
        "ShellBinding": false,
        "SoulBinding": false
      }
    },
    "04": {
      "Name": "04",
      "MaxHealth": 9,
      "MaxMP": 198,
      "NailDamage": 5,
      "CharmSlots": 11,
      "HasAllMoveAbilities": true,
      "HasMoveAbilities": {
        "AcidArmour": false,
        "Dash": false,
        "Walljump": false,
        "SuperDash": false,
        "ShadowDash": false,
        "DoubleJump": false
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
    }
  }
```

## Fields

### Explanation : binds

**Preset Name**: The key in the `"binds"` object is the exact name of a gear preset defined in the main JSON array. For example, if you have a preset with `"Name": "04"`, then you can bind a key to it.\

**Keyboard Key**: The value associated with each preset name is the keyboard key that activates that preset. The key names are based on the KeyCode enum in Unity. See link to unity keycode enum for supported values. Example key values:
Alpha0, Alpha1, Alpha2, …, Alpha9 (the number keys on the main keyboard)

* A, B, C, …, Z (letter keys)
* F1, F2, …, F12 (function keys)
* Keypad0, Keypad1, … Keypad9 (keypad number keys)
* LeftShift, RightShift, LeftControl, RightControl, LeftAlt, RightAlt
* Space
* Return (Enter)
* Escape
* Tab

**Case Sensitivity**: Preset names in the "binds" object are case-sensitive and must exactly match the "Name" field in your gear preset definitions.\

**Valid Key Codes**: Only use valid KeyCode values from Unity. Using an invalid key code will likely result in an error. Refer to the Unity documentation for a complete list of available key codes.\

**Key Conflicts**: Be aware that key bindings may conflict with other mods or with the game’s default controls. If you experience conflicts, you’ll need to choose different key bindings.\

**Missing Bindings**: If a preset does not have a binding defined in the "binds" object, it cannot be activated via a hotkey.\

**Overriding Bindings**: If the same key is assigned to multiple presets, the last definition will take precedence. Avoid assigning the same key to multiple presets.\

**Error Handling**: Check the mod's log file if key binding is not working. You can also reset bindings to standard ones in the mod settings menu.\


### Explanation : presetEquipments

*   `Name`: (string) The name of the preset.
*   `MaxHealth`: (integer) Maximum health.
*   `MaxMP`: (integer) Maximum MP (Soul).
*   `NailDamage`: (integer) Nail damage level.
*   `CharmSlots`: (integer) Number of available charm slots.
*   `HasAllMoveAbilities`: (boolean) Whether all movement abilities are unlocked. If true, the `HasMoveAbilities` field is ignored.
*   `HasMoveAbilities`: (object) An object containing booleans for each movement ability:
    *   `AcidArmour`: (boolean) Has acid armor.
    *   `Dash`: (boolean) Has dash.
    *   `Walljump`: (boolean) Has wall jump.
    *   `SuperDash`: (boolean) Has super dash.
    *   `ShadowDash`: (boolean) Has shadow dash.
    *   `DoubleJump`: (boolean) Has double jump.
*   `AllSpelsLvl`: (integer) The level of all spells. If 1, the `SpelsLvl` is ignored.
*   `SpelsLvl`: (object) An object containing integers for each spell level:
    *   `fireballLevel`: (integer) Fireball level.
    *   `quakeLevel`: (integer) Quake level.
    *   `screamLevel`: (integer) Scream level.
*   `HasAllNailArts`: (boolean) Whether all nail arts are unlocked. If true, the `HasNailArts` field is ignored.
*   `HasNailArts`: (object) An object containing booleans for each nail art:
    *   `hasCyclone`: (boolean) Has cyclone slash.
    *   `hasDashSlash`: (boolean) Has dash slash.
    *   `hasUpwardSlash`: (boolean) Has upward slash.
*   `LvlDreamNail`: (integer) Dream nail level.
*   `HasAllBindings`: (boolean) Whether all bindings are active. If true, the `Bindings` field is ignored.
*   `Bindings`: (object) An object containing booleans for each binding:
    *   `CharmsBinding`: (boolean) Charm binding.
    *   `NailBinding`: (boolean) Nail binding.
    *   `ShellBinding`: (boolean) Shell binding.
    *   `SoulBinding`: (boolean) Soul binding.
## Usage

Edit a HelperForChallenge.GlobalSettings.jsonn file with your desired presets in the format shown above.
In-game, press the configured hotkeys to cycle through your presets.

## Future Features

Hotkey customization.
UI for preset management within the game.

## Test Version (v1.0.0.0-beta

This is a test version of the mod. Currently, it includes 4 pre-defined presets. You can activate these presets by pressing the 1, 2, 3, and 4 keys on your keyboard respectively during gameplay. These keys directly select the corresponding preset from the HelperForChallenge.GlobalSettings.json file.
