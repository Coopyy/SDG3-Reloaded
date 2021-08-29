using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace SDG3R.Server.Classes
{
    public class Gamemode
    {
        public Gamemode()
        {

        }

        public void AddComponent(Type t)
        {
            Server.GamemodesObj.AddComponent(t);
        }

        public virtual void Load()
        {

        }

        public virtual void Unload()
        {

        }
    }
}
