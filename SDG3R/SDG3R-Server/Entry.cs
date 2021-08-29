using Newtonsoft.Json;
using SDG.Framework.Modules;
using SDG3R.Core.Classes;
using SDG3R.Core.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace SDG3R.Server
{
    public class Entry : IModuleNexus
    {
        public void initialize()
        {
            Console.Clear();
            IConsole.SendConsole("SDG3 Reloaded", ConsoleColor.Cyan);
            Server.GamemodesObj = new GameObject();
            GameObject.DontDestroyOnLoad(Server.GamemodesObj);
            Utilities.Environment.Setup();
            Server.ServerData.TrySwitchGamemode();
            IConsole.SendConsole("Preparing: " + Server.ServerData.CurrentModeData.GetGamemodeString(), ConsoleColor.Cyan);
        }


        public void shutdown()
        {
        }
    }
}
