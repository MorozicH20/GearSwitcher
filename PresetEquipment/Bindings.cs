using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace HelperForChallenge.PresetEquipment
{
    internal class Bindings
    {
        public void INIT()
        {
            On.BossSequenceController.ApplyBindings += ApplyPreset;
        }

        private void BindingsNail()
        {
            BossSequence.
            int @int = GameManager.instance.playerData.GetInt("nailDamage");
            if (@int > 13)
            {
                GameManager.instance.playerData.SetInt("nailDamage", Mathf.RoundToInt((float)(@int*0.8f)));
            }
            EventRegister.SendEvent("SHOW BOUND NAIL");

        }

        private void BindingsCharm()
        {
            GameManager.instance.playerData.GetVariable<List<int>>("equippedCharms").ToArray();
            GameManager.instance.playerData.GetVariable<List<int>>("equippedCharms").Clear();
            GameManager.instance.playerData.GetBool("overcharmed");
            GameManager.instance.playerData.SetBool("overcharmed", false);

            foreach (int num in PlayerData.instance.equippedCharms)
            {
                GameManager.instance.SetPlayerDataBool(num.ToString(), false);
            }

            EventRegister.SendEvent("SHOW BOUND CHARMS");
        }

        private void BindingsBoundSoul()
        {
            EventRegister.SendEvent("BIND VESSEL ORB");

        }

        private void BindingsShell()
        {

            var boundShellGetter = typeof(BossSequenceController).GetMethod($"get_BoundShell", BindingFlags.Public | BindingFlags.Static);
            var boundMaxHealthGetter = typeof(BossSequenceController).GetMethod($"get_BoundMaxHealth", BindingFlags.Public | BindingFlags.Static);

            _detours = new(2)
            {
                new Hook(boundShellGetter, new Func<bool>(() => true), TBConstants.HookManualApply),
                new Hook(boundMaxHealthGetter, new Func<int>(BoundMaxHealthOverride), TBConstants.HookManualApply)
            };

        }

        private void ApplyPreset(On.BossSequenceController.orig_ApplyBindings orig)
        {

            HeroController.instance.CharmUpdate();
            PlayMakerFSM.BroadcastEvent("CHARM EQUIP CHECK");
            EventRegister.SendEvent("UPDATE BLUE HEALTH");
            PlayMakerFSM.BroadcastEvent("HUD IN");


            GameManager.instance.playerData.ClearMP();
            GameManager.instance.soulOrb_fsm.SendEvent("MP LOSE");
            GameManager.instance.soulVessel_fsm.SendEvent("MP RESERVE DOWN");
            PlayMakerFSM.BroadcastEvent("CHARM INDICATOR CHECK");
        }

        public void ApplyPreset()
        {

        }

    }
}
