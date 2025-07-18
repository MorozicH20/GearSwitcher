# GearSwitcher - Hollow Knight Mod

## Introduction

**GearSwitcher** allows players to quickly switch between pre-defined gear presets in *Hollow Knight*. This is useful for challenges, speedruns, or experimenting with different builds on the fly.

## Dependencies

- [ToggleableBindings](https://github.com/Unordinal/HollowKnight.ToggleableBindings) (v0.13)

## Features

- **Preset Management**: Save and load custom gear and charm builds.
- **In-Game Switching**: Instantly swap between presets using customizable hotkeys.
- **Free Charms**: Option to make all charms cost 0 notches.

---

## Installation

Make sure you have the Hollow Knight modding API installed (e.g., Modding API).

1. Place the `GearSwitcher.dll` file into your Hollow Knight `Mods` folder.
2. Run the game.

---

## Configuration

The mod uses a JSON file to store and manage presets. You can customize the following settings:

- **Preset File**: Presets are stored in a JSON file located at:  
  `C:\Users\<User>\AppData\LocalLow\Team Cherry\Hollow Knight\GearSwitcher.GlobalSettings.json`

- **Hotkey Customization**: Configure hotkeys to switch between presets.

---

### Preset JSON Structure

The main configuration file is a JSON object consisting of two dictionaries and two boolean variables:

- `Keybinds`
- `presetEquipments`
- `isSaveEquippedCharms`
- `isFreeCharms`

**Example JSON:**

```json
{
  "Keybinds": {
    "FullGear": "Key0",
    "O4": "Key1",
    "Ow": "Key2",
    "Itemless": "Key3",
    "NMA": "Key4",
    "NNA": "Key5",
    "NailOnly": "Key6",
    "Custom1": "None",
    "Custom2": "None",
    "Custom3": "None",
    "Custom4": "None",
    "Custom5": "None"
  },
  "isSaveEquippedCharms": true,
  "isFreeCharms": false,
  "presetEquipments": {
    "FullGear": {
      "Name": "FullGear",
      "MaxHealth": 9,
      "SoulVessels": 3,
      "NailDamage": 21,
      "CharmSlots": 11,
      "EquippedCharms": [2, 1, 31],
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
      "SoulVessels": 3,
      "NailDamage": 5,
      "CharmSlots": 11,
      "EquippedCharms": null,
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
    },
  }
}
```
## Field Explanations

### Keybinds

- **Preset Name**: The key in the `Keybinds` object must exactly match the `"Name"` field of a defined preset.
- **Keyboard Key**: The value is a key string from the InControl KeyCode enum.

Examples of valid key values:
- Key0, Key1, ..., Key9 (number keys)
- A, B, C, ..., Z (letter keys)
- F1, F2, ..., F12 (function keys)
- Pad0, Pad1, ..., Pad9 (numpad keys)
- LeftShift, RightShift, LeftControl, RightControl, LeftAlt, RightAlt
- Space
- Return (Enter)
- Escape
- Tab

Notes:
- Key names are case-sensitive and must match exactly.
- Invalid key names may cause errors or prevent activation.
- Avoid assigning the same key to multiple presets or keys already used by the game or other mods to prevent conflicts.
- Presets with no key defined cannot be activated via hotkey.
- If keybinds do not work, check the mod log file for errors.

### presetEquipments

Each gear preset contains the following fields:

- `Name` (string): The name of the preset.
- `MaxHealth` (int): Maximum health.
- `SoulVessels` (int): Number of soul vessels.
- `NailDamage` (int): Nail damage value.
- `CharmSlots` (int): Number of available charm slots.
- `EquippedCharms` (list of int): List of charm IDs to equip.
- `HasAllMoveAbilities` (bool): If true, overrides the `HasMoveAbilities` section.
- `HasMoveAbilities` (object of bools):
  - `AcidArmour`
  - `Dash`
  - `Walljump`
  - `SuperDash`
  - `ShadowDash`
  - `DoubleJump`
- `AllSpelsLvl` (int): If set, overrides individual spell levels.
- `SpelsLvl` (object of ints):
  - `fireballLevel`
  - `quakeLevel`
  - `screamLevel`
- `HasAllNailArts` (bool): If true, overrides the `HasNailArts` section.
- `HasNailArts` (object of bools):
  - `hasCyclone`
  - `hasDashSlash`
  - `hasUpwardSlash`
- `LvlDreamNail` (int): Dream Nail upgrade level.
- `HasAllBindings` (bool): If true, overrides the `Bindings` section.
- `Bindings` (object of bools):
  - `CharmsBinding`
  - `NailBinding`
  - `ShellBinding`
  - `SoulBinding`

## Preset and Keybind Customization via Menu

GearSwitcher includes an in-game interface to manage presets and keybindings.

- **Configure Custom Presets**: Add, delete, or edit gear presets from within the game.
- **Configure Keybinds**: Assign hotkeys to each preset through a dedicated menu.
- **Save Charm Builds**: Allows you to save a charm build separately for each preset.
- **Free Charms**: If enabled, all charms cost 0 notches. If disabled, charms use their normal cost.
