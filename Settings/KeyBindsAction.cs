﻿using InControl;


namespace GearSwitcher.Settings
{
    public class KeyBindsAction : PlayerActionSet
    {
        public PlayerAction FullSave;
        public PlayerAction Ab;
        public PlayerAction O4;
        public PlayerAction Ow;
        public PlayerAction ItemLess;
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
            Ab = CreatePlayerAction("Ab");
            O4 = CreatePlayerAction("O4");
            Ow = CreatePlayerAction("Ow");
            ItemLess = CreatePlayerAction("ItemLess");
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
            Ab.AddDefaultBinding(Key.Key1);
            O4.AddDefaultBinding(Key.Key2);
            Ow.AddDefaultBinding(Key.Key3);
            ItemLess.AddDefaultBinding(Key.Key4);
            NMA.AddDefaultBinding(Key.Key5);
            NNA.AddDefaultBinding(Key.Key6);
            NailOnly.AddDefaultBinding(Key.Key7);
        }
    }
}