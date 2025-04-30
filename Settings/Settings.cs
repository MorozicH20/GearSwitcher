using System;
using System.IO;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using UnityEngine;
using Modding.Converters;

namespace GearSwitcher.Settings
{
    //Empty class required for DebugMod class definition
    public class SaveSettings { }

    public class GlobalSettings
    {

        [JsonConverter(typeof(PlayerActionSetConverter))]
        public KeyBindsAction Keybinds = new();

        //[JsonProperty(ItemConverterType = typeof(StringEnumConverter))]
        public Dictionary<string, SavePresetEquipments> presetEquipments = new Dictionary<string, SavePresetEquipments>();

    }
}