using System;
using System.IO;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using UnityEngine;

namespace HelperForChallenge
{
    //Empty class required for DebugMod class definition
    public class SaveSettings { }

    [Serializable]
    public class KeyBinds
    {
        public Dictionary<string, string> binds_to_file = new Dictionary<string, string>();
    }

    public class GlobalSettings
    {
        //Save members
        [JsonProperty(ItemConverterType = typeof(StringEnumConverter))]
        public Dictionary<string, KeyCode> binds = new Dictionary<string, KeyCode>();
        
        //[JsonProperty(ItemConverterType = typeof(StringEnumConverter))]
        public Dictionary<string, SavePresetEquipments> presetEquipments = new Dictionary<string, SavePresetEquipments>();

    }
}