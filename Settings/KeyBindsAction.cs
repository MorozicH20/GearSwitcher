using InControl;
using System;
using System.Collections.Generic;
using System.Linq;

namespace GearSwitcher.Settings
{
    /// <summary>
    /// Stores Keybinds
    /// </summary>
    public class KeyBindsAction : PlayerActionSet
    {
        //public PlayerAction FullSave;
        //public PlayerAction O4;
        //public PlayerAction Ow;
        //public PlayerAction ItemLess;
        //public PlayerAction NMA;
        //public PlayerAction NNA;
        //public PlayerAction NailOnly;

        //public PlayerAction Custom1;
        //public PlayerAction Custom2;
        //public PlayerAction Custom3;
        //public PlayerAction Custom4;
        //public PlayerAction Custom5;

        public PlayerAction[] PlayerActions;
        public KeyBindsAction(Dictionary<string, SavePresetEquipments> presets)
        {
            PlayerActions = new PlayerAction[presets.Count];
            var ArrayPreset = presets.Keys.ToArray();

            for (int i = 0; i < presets.Keys.Count; i++)
            {
                try
                {
                    PlayerActions[i] = new PlayerAction(ArrayPreset[i], this);
                }
                catch (Exception ex)
                {
                    Modding.Logger.Log(ex.Message);
                }
            }
            Modding.Logger.Log("Completed init PlayerAction");
            DefaultBinds();
        }
        public KeyBindsAction()
        {

        }

        private void DefaultBinds()
        {
            try
            {
                Modding.Logger.Log("0");

                if (PlayerActions == null) return;

                for (int i = 0; i < PlayerActions.Length; i++)
                {
                    if (i >= 10) break;

                    PlayerActions[i].AddDefaultBinding(Key.Key0 + i);
                }

            }
            catch (Exception ex)
            {
                Modding.Logger.Log(ex.Message);

            }
        }
    }
}