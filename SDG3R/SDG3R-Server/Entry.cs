using HarmonyLib;
using Newtonsoft.Json;
using SDG.Framework.Modules;
using SDG.Unturned;
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
        private Harmony hInstance;
        public void initialize()
        {
            if (!Provider.isServer && !Dedicator.isDedicated)
                return;

            Console.Clear();
            IConsole.SendConsole("SDG3 Reloaded", ConsoleColor.Cyan);
            IConsole.SendConsole("Patching Methods", ConsoleColor.Yellow);
            hInstance = new Harmony("SDG3R.Server");
            hInstance.PatchAll();

            Server.GamemodesObj = new GameObject();
            GameObject.DontDestroyOnLoad(Server.GamemodesObj);
            Utilities.Environment.Setup();
            Server.ServerData.TrySwitchGamemode();
        }


        public void shutdown()
        {
        }
    }
}
