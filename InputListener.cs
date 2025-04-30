using GearSwitcher.ModMenu;
using Satchel;
using UnityEngine;
using System.Collections;
using System;

namespace GearSwitcher
{
    internal static class InputListener
    {
        private static Coroutine inputCoroutine;

        internal static void Start()
        {
            inputCoroutine = CoroutineHelper.GetRunner().StartCoroutine(ListenForInput());
        }

        private static IEnumerator ListenForInput()
        {

            while (true)
            {
                try
                {
                    if (GearSwitcher.settings == null || GearSwitcher.settings.Keybinds == null || GearSwitcher.settings.Keybinds.PlayerActions == null || GearSwitcher.settings.Keybinds.PlayerActions.Length < 1)
                    {

                        GearSwitcher.SetDefultPresets();
                    }

                    for (int i = 0; i < GearSwitcher.settings.Keybinds.PlayerActions.Length; i++)
                    {

                        if (GameManager.instance != null && !(GameManager.instance.isPaused))
                        {
                            Modding.Logger.Log(GearSwitcher.settings.Keybinds.PlayerActions);
                            Modding.Logger.Log(GearSwitcher.settings.Keybinds.PlayerActions[i]);

                            if (GearSwitcher.settings.Keybinds.PlayerActions[i].WasPressed)
                            {

                                ManagerResurse.SetPreset(GearSwitcher.settings.presetEquipments[GearSwitcher.settings.Keybinds.PlayerActions[i].Name]);
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    Modding.Logger.Log(ex.Message);

                }
                yield return new WaitForEndOfFrame();
            }

        }

    }
}