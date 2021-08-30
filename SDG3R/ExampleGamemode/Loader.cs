using SDG3R.Core.Logging;
using SDG3R.Server.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace ExampleGamemode
{
    public class Loader : Gamemode
    {
        public override void Load()
        {
            IConsole.SendConsole("ExampleGamemode Loaded!");
            AddComponent(typeof(Manager));
        }
    }
}
