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
        public bool isFreeCharms = false;

        public Dictionary<string, SavePresetEquipments> presetEquipments = new Dictionary<string, SavePresetEquipments>();

        public GlobalSettings()
        {

           var FullGear = DefaultPresets.FullGear();
            var AB = DefaultPresets.AB();
            var O4 = DefaultPresets.O4();
            var Ow = DefaultPresets.Ow();
            var Itemless = DefaultPresets.Itemless();
            var NMA = DefaultPresets.NMA();
            var NNA = DefaultPresets.NNA();
            var NailOnly = DefaultPresets.NailOnly();

            var Custom1 = DefaultPresets.FullGear();
            Custom1.Name = "Custom1";

            var Custom2 = DefaultPresets.FullGear();
            Custom2.Name = "Custom2";

            var Custom3 = DefaultPresets.FullGear();
            Custom3.Name = "Custom3";

            var Custom4 = DefaultPresets.FullGear();
            Custom4.Name = "Custom4";

            var Custom5 = DefaultPresets.FullGear();
            Custom5.Name = "Custom5";

            presetEquipments = new() {
                { FullGear.Name, FullGear },
                { AB.Name,AB  },
                { O4.Name, O4 },
                { Ow.Name, Ow },
                { Itemless.Name, Itemless },
                { NMA.Name, NMA },
                { NNA.Name, NNA },
                { NailOnly.Name,NailOnly  },

                { Custom1.Name, Custom1 },
                { Custom2.Name, Custom2 },
                { Custom3.Name, Custom3 },
                { Custom4.Name, Custom4 },
                { Custom5.Name, Custom5 },


             };
        }

    }

    public class LocalSettings
    {
        public string LastPreset = null;
    }
}