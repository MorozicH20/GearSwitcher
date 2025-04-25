using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using HelperForChallenge.Bindings;
using HelperForChallenge.PresetEquipment;
using HelperForChallenge;
using HutongGames.PlayMaker;
using MonoMod.RuntimeDetour;
using UnityEngine;
using ToggleableBindings;

namespace HelperForChallenge.Bindings
{
    internal class CharmBinding : Binding
    {
        public static bool AllowEssentialCharms { get; private set; } = true;

        internal static int[] ExemptCharms =
        {
            36, // Void Heart
            40, // Grimmchild
        };
        public CharmBinding() : base("Charms")
        {
            var boundCharmsGetter = typeof(BossSequenceController).GetMethod($"get_BoundCharms", BindingFlags.Public | BindingFlags.Static);


            //_detours = new(1)
            //{
            //    new Hook(boundCharmsGetter, new Func<bool>(() => true), TBConstants.HookManualApply)
            //};
        }
        public static PlayMakerFSM? CharmsMenuFsm
        {
            get
            {
                var charmsPaneGO = GameObject.FindWithTag("Charms Pane");
                return PlayMakerUtils.FindFsmOnGameObject(charmsPaneGO, "UI Charms");
            }
        }

        private const string ShowBoundCharmsEvent = "SHOW BOUND CHARMS";
        private const string HideBoundCharmsEvent = "HIDE BOUND CHARMS";
        private const string CharmEquipCheckEvent = "CHARM EQUIP CHECK";
        private const string CharmIndicatorCheckEvent = "CHARM INDICATOR CHECK";

        private List<int> _previousEquippedCharms = new();
        private bool _wasOvercharmed;

        private readonly List<IDetour> _detours;

        public override void Applied()
        {
            base.Applied();
            HudEvents.In += HudEvents_In;

            var equippedCharms = PlayerData.instance.equippedCharms.ToArray();
            Modding.Logger.Log(_previousEquippedCharms.Count);
            _previousEquippedCharms =new(equippedCharms);
            Modding.Logger.Log(_previousEquippedCharms.Count);

            _wasOvercharmed = PlayerData.instance.overcharmed;

            var charmsAllowed = equippedCharms.ToLookup(id => AllowEssentialCharms && ExemptCharms.Contains(id));
            ToggleCharms(charmsAllowed[false], false);



            PlayerData.instance.CalculateNotchesUsed();
            HeroController.instance.CharmUpdate();


            //GameManager.instance.playerData.GetVariable<List<int>>("equippedCharms").ToArray();
            GameManager.instance.playerData.GetVariable<List<int>>("equippedCharms").Clear();

            Modding.Logger.Log(_previousEquippedCharms.Count);

            //GameManager.instance.playerData.GetBool("overcharmed");
            GameManager.instance.playerData.SetBool("overcharmed", false);


            PlayMakerFSM.BroadcastEvent(CharmEquipCheckEvent);
            PlayMakerFSM.BroadcastEvent(CharmIndicatorCheckEvent);
            PlayMakerFSM.BroadcastEvent(ShowBoundCharmsEvent);

            if (CharmsMenuFsm != null)
                CharmsMenuFsm.SetState("Activate UI");
        }

        public override void Restored()
        {
            base.Restored();

            HudEvents.In -= HudEvents_In;
            ToggleCharms(PlayerData.instance.equippedCharms.ToArray(), false);

            Modding.Logger.Log(_previousEquippedCharms.Count);

            PlayerData.instance.equippedCharms = _previousEquippedCharms.ToList();
            PlayerData.instance.overcharmed = _wasOvercharmed;

            Modding.Logger.Log(_previousEquippedCharms.Count);


            ToggleCharms(_previousEquippedCharms, true);

            PlayerData.instance.CalculateNotchesUsed();
            HeroController.instance.CharmUpdate();
            PlayMakerFSM.BroadcastEvent(CharmEquipCheckEvent);
            PlayMakerFSM.BroadcastEvent(CharmIndicatorCheckEvent);

            EventRegister.SendEvent(HideBoundCharmsEvent);

            if (CharmsMenuFsm != null)
                CharmsMenuFsm.SetState("Activate UI");


        }

        private void ToggleCharms(IEnumerable<int> charmIDs, bool state)
        {
            foreach (var charmID in charmIDs)
                PlayerData.instance.SetBool($"equippedCharm_{charmID}", state);
        }

        private void HudEvents_In()
        {
            EventRegister.SendEvent(ShowBoundCharmsEvent);
        }

    }
}
