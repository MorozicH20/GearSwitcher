using System;
using System.Collections;
using System.Collections.Generic;
using Modding;
using UnityEngine;
using UObject = UnityEngine.Object;
using HelperForChallenge.PresetEquipment;
using HelperForChallenge.Bindings;

namespace HelperForChallenge
{
    public class HelperForChallenge : Mod
    {
        internal static HelperForChallenge Instance;

        private Binding _test;
        public HelperForChallenge() : base(ModInfo.Name) { }

        public override void Initialize()
        {
            _test = new CharmBinding();

            base.Initialize();
            ModHooks.HeroUpdateHook += OnHeroUpdate;

        }

        private void OnHeroUpdate()
        {
            if (Input.GetKeyDown(KeyCode.Q))
            {
                if (_test.IsApplied)
                    _test.Restored();
                else
                    _test.Applied();

            }

        }

        public override string GetVersion() => ModInfo.Version;

    }
}