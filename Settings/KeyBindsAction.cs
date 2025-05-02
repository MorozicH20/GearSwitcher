using InControl;
using System;
using System.Collections.Generic;
using System.Linq;

namespace GearSwitcher.Settings
{
    public class KeyBindsAction : PlayerActionSet
    {
        public PlayerAction FullSave;
        public PlayerAction O4;
        public PlayerAction Ow;
        public PlayerAction Itemless;
        public PlayerAction NMA;
        public PlayerAction NNA;
        public PlayerAction NailOnly;

        public PlayerAction Custom1;
        public PlayerAction Custom2;
        public PlayerAction Custom3;
        public PlayerAction Custom4;
        public PlayerAction Custom5;
        public KeyBindsAction()
        {

            FullSave = CreatePlayerAction("FullSave");
            O4 = CreatePlayerAction("O4");
            Ow = CreatePlayerAction("Ow");
            Itemless = CreatePlayerAction("Itemless");
            NMA = CreatePlayerAction("NMA");
            NNA = CreatePlayerAction("NNA");
            NailOnly = CreatePlayerAction("NailOnly");
            Custom1 = CreatePlayerAction("Custom1");
            Custom2 = CreatePlayerAction("Custom2");
            Custom3 = CreatePlayerAction("Custom3");
            Custom4 = CreatePlayerAction("Custom4");
            Custom5 = CreatePlayerAction("Custom5");

            DefaultBinds();

        }

        private void DefaultBinds()
        {
            FullSave.AddDefaultBinding(Key.Key0);
            O4.AddDefaultBinding(Key.Key1);
            Ow.AddDefaultBinding(Key.Key2);
            Itemless.AddDefaultBinding(Key.Key3);
            NMA.AddDefaultBinding(Key.Key4);
            NNA.AddDefaultBinding(Key.Key5);
            NailOnly.AddDefaultBinding(Key.Key6);

            //Custom1.AddDefaultBinding(Key.);
            //Custom2.AddDefaultBinding(Key.Key0);
            //Custom3.AddDefaultBinding(Key.Key0);
            //Custom4.AddDefaultBinding(Key.Key0);
            //Custom5.AddDefaultBinding(Key.Key0);
        }
    }
}