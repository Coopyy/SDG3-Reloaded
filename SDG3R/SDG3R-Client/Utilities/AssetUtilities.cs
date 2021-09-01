using SDG3R.Core.Logging;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace SDG3R.Client.Utilities
{
    public class AssetUtilities
    {
        public static GUISkin SDG3RSkin = null;
        public static void LoadAssets()
        {
            string path = Application.dataPath + "/SDG3R.assets";
            if (!File.Exists(path))
            {
                IConsole.SendConsole("SDG3R UI assets not found. It's recommended you verify SDG3R files", ConsoleColor.Red);
                return;
            }
            AssetBundle Bundle = AssetBundle.LoadFromMemory(File.ReadAllBytes(path));
            SDG3RSkin = Bundle.LoadAllAssets<GUISkin>().First();
        }
    }
}
