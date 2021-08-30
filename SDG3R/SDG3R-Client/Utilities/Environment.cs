using HarmonyLib;
using Newtonsoft.Json;
using SDG.Unturned;
using SDG3R.Core.Classes;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace SDG3R.Client.Utilities
{
    public class Environment
    {
        public static void Setup()
        {
            if (!Directory.Exists("/References/"))
                Directory.CreateDirectory("/References/");
            foreach (string s in Directory.GetFiles("/References/", "*.dll"))
                Assembly.LoadFile(string.Format("/References/{0}.dll", s));
        }
    }
}
