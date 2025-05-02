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

                    for (int i = 0; i < GearSwitcher.settings.Keybinds.Actions.Count; i++)
                    {

                        if (GameManager.instance != null && !(GameManager.instance.isPaused))
                        {

                            if (GearSwitcher.settings.Keybinds.Actions[i].WasPressed)
                            {
                                ManagerResurse.SetPreset(GearSwitcher.settings.presetEquipments[GearSwitcher.settings.Keybinds.Actions[i].Name]);
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