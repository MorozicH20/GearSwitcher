using System;
using System.Collections;
using System.Collections.Generic;
using Modding;
using UnityEngine;
using UObject = UnityEngine.Object;
//using HelperForChallenge.PresetEquipment;
using ToggleableBindings;
using UnityEngine.PlayerLoop;
namespace HelperForChallenge
{
    public class HelperForChallenge : Mod
    {
      
        //internal static HelperForChallenge Instance;

        bool isCharms = false;
        public string IDCharmsBinding = "ToggleableBindings::CharmsBinding";

        bool isNail = false;
        public string IDNailBinding = "ToggleableBindings::NailBinding";

        bool isShell = false;
        public string IDShellBinding = "ToggleableBindings::ShellBinding";

        bool isSoul = false;
        public string IDSoulBinding = "ToggleableBindings::SoulBinding";


        public HelperForChallenge() : base(ModInfo.Name) { }
        public override void Initialize()
        {

            base.Initialize();
            ModHooks.HeroUpdateHook += OnHeroUpdate;


        }

        private void OnHeroUpdate()
        {
            if (Input.GetKeyDown(KeyCode.Alpha1))
            {
                var Charms = BindingManager.GetBinding(IDCharmsBinding);
                if (isCharms)
                {
                    isCharms = false;
                    BindingManager.RestoreBinding(IDCharmsBinding);
                }
                else
                {
                    isCharms = true;
                    BindingManager.ApplyBinding(IDCharmsBinding);
                }
            }

            if (Input.GetKeyDown(KeyCode.Alpha2))
            {
                var Charms = BindingManager.GetBinding(IDNailBinding);
                if (isNail)
                {
                    isNail = false;
                    BindingManager.RestoreBinding(IDNailBinding);
                }
                else
                {
                    isNail = true;
                    BindingManager.ApplyBinding(IDNailBinding);
                }
            }

            if (Input.GetKeyDown(KeyCode.Alpha3))
            {
                var Charms = BindingManager.GetBinding(IDShellBinding);
                if (isShell)
                {
                    isShell = false;
                    BindingManager.RestoreBinding(IDShellBinding);
                }
                else
                {
                    isShell = true;
                    BindingManager.ApplyBinding(IDShellBinding);
                }
            }

            if (Input.GetKeyDown(KeyCode.Alpha4))
            {
                var Charms = BindingManager.GetBinding(IDSoulBinding);
                if (isSoul)
                {
                    isSoul = false;
                    BindingManager.RestoreBinding(IDSoulBinding);
                }
                else
                {
                    isSoul = true;
                    BindingManager.ApplyBinding(IDSoulBinding);
                }
            }

        }

        public override string GetVersion() => ModInfo.Version;

    }
}