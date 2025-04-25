using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine.Networking.Types;

namespace HelperForChallenge.PresetEquipment
{
    public abstract class Binding
    {
        public string Name;


        public bool IsApplied { get; private set; }

        protected Binding(string name)
        {
            if (name == null)
                throw new ArgumentNullException(nameof(name));

        }

        public virtual void Applied()
        {
            if (IsApplied)
                return;

            IsApplied = true;
        }
        public virtual void Restored()
        {
            if (!IsApplied)
                return;

            IsApplied = false;
        }

        //public bool IsVanillaBinding { get; }
    }
}
