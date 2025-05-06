using Satchel;
using UnityEngine;
using System.Collections;
using System.Linq;

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
                for (int i = 0; i < GearSwitcher.settings.Keybinds.Actions.Count; i++)
                {

                    if (GameManager.instance != null && !(GameManager.instance.isPaused))
                    {

                        if (GearSwitcher.settings.Keybinds.Actions[i].WasPressed)
                        {
                            if (GearSwitcher.settings.isSaveСollectionsCharms || GearSwitcher.localSettings.LastPreset != null)
                                GearSwitcher.settings.presetEquipments[GearSwitcher.localSettings.LastPreset].EquippedCharms = PlayerData.instance.equippedCharms.ToList();
                            ManagerResurse.SetPreset(GearSwitcher.settings.presetEquipments[GearSwitcher.settings.presetEquipments.Keys.ToArray()[i]]);
                        }
                    }
                }
                yield return new WaitForEndOfFrame();
            }
        }
    }
}