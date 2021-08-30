using HarmonyLib;
using Microsoft.Win32.SafeHandles;
using SDG.Framework.Modules;
using SDG.Unturned;
using SDG3R.Client.Attributes;
using SDG3R.Client.UI;
using SDG3R.Client.Utilities;
using SDG3R.Core.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using UnityEngine;

namespace SDG3R.Client
{
    public class Entry : IModuleNexus
    {
        public static GameObject gO = null;
        public void initialize()
        {
            Assembly.LoadFile($"{Directory.GetCurrentDirectory()}\\Unturned_Data\\0Harmony.dll");
            gO = new GameObject();
            UnityEngine.Object.DontDestroyOnLoad(gO);

            IConsole.Setup();
            IConsole.SendConsole("SDG3 Reloaded", ConsoleColor.Cyan);
            Utilities.Environment.Setup();
            foreach (Type T in Assembly.GetExecutingAssembly().GetTypes())
            {
                if (T.IsDefined(typeof(MonoComponent), false))
                {
                    IConsole.SendConsole("Adding Component: " + T.FullName, ConsoleColor.Green);
                    gO.AddComponent(T);
                }
            }
        }


        public void shutdown()
        {
        }
    }
}
