using System.Collections.Generic;
using Newtonsoft.Json;
using Modding.Converters;

namespace GearSwitcher.Settings
{
    public class SaveSettings { }

    public class GlobalSettings
    {
        [JsonConverter(typeof(PlayerActionSetConverter))]
        public KeyBindsAction Keybinds = new();

        public bool isSaveСollectionsCharms = false;

        public Dictionary<string, SavePresetEquipments> presetEquipments = new Dictionary<string, SavePresetEquipments>();

    }

    public class LocalSettings
    {
        public string LastPreset = null;
    }
}