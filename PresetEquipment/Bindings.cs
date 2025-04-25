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
        }

        private void BindingsNail()
        {
            
            int @int = GameManager.instance.playerData.GetInt("nailDamage");
            if (@int > 13)
            {
                GameManager.instance.playerData.SetInt("nailDamage", Mathf.Clamp(Mathf.RoundToInt((float)(@int*0.8f)),0,13));
            }
            EventRegister.SendEvent("SHOW BOUND NAIL");

        }

        private void BindingsCharm()
        {
            foreach (int num in PlayerData.instance.equippedCharms)
            {
                GameManager.instance.SetPlayerDataBool(num.ToString(), false);
            }

            GameManager.instance.playerData.GetVariable<List<int>>("equippedCharms").ToArray();
            GameManager.instance.playerData.GetVariable<List<int>>("equippedCharms").Clear();
            GameManager.instance.playerData.GetBool("overcharmed");
            GameManager.instance.playerData.SetBool("overcharmed", false);


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

           
        }

        //public void ApplyPreset(On.BossSequenceController.orig_ApplyBindings orig)
        //{
        //    BindingsNail();
        //    BindingsCharm();
        //    HeroController.instance.CharmUpdate();
        //    PlayMakerFSM.BroadcastEvent("CHARM EQUIP CHECK");
        //    EventRegister.SendEvent("UPDATE BLUE HEALTH");
        //    PlayMakerFSM.BroadcastEvent("HUD IN");


        //    GameManager.instance.playerData.ClearMP();
        //    GameManager.instance.soulOrb_fsm.SendEvent("MP LOSE");
        //    GameManager.instance.soulVessel_fsm.SendEvent("MP RESERVE DOWN");
        //    PlayMakerFSM.BroadcastEvent("CHARM INDICATOR CHECK");
        //}

        public void ApplyPreset()
        {
            BindingsNail();
            BindingsCharm();
            HeroController.instance.CharmUpdate();
            PlayMakerFSM.BroadcastEvent("CHARM EQUIP CHECK");
            EventRegister.SendEvent("UPDATE BLUE HEALTH");
            PlayMakerFSM.BroadcastEvent("HUD IN");
            BindingsBoundSoul();

            GameManager.instance.playerData.ClearMP();
            GameManager.instance.soulOrb_fsm.SendEvent("MP LOSE");
            GameManager.instance.soulVessel_fsm.SendEvent("MP RESERVE DOWN");
            PlayMakerFSM.BroadcastEvent("CHARM INDICATOR CHECK");
            BindingsShell();
        }

    }
}
