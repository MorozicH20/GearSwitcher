using System;
using System.Collections;
using System.Collections.Generic;
using Modding;
using UnityEngine;
using UObject = UnityEngine.Object;

namespace HelperForChallenge
{
    public class HelperForChallenge : Mod
    {
        internal static HelperForChallenge Instance;

        public HelperForChallenge() : base(ModInfo.Name) { }

        public override void Initialize()
        {
            base.Initialize();
        }
        public override string GetVersion() => ModInfo.Version;
       
    }
}