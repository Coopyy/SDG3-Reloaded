using Newtonsoft.Json;
using SDG.Unturned;
using SDG3R.Core.Classes;
using SDG3R.Core.Logging;
using SDG3R.Server.Classes;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace SDG3R.Server.Utilities
{
    public class GamemodeUtilities
    {
        private static Type p = null;
        public static bool IsGamemodeExist(string gamemode)
        {
            string gmdir = string.Format("Servers/{0}/SDG3R/Gamemodes/{1}/{1}.dll", Dedicator.serverID, gamemode);
            if (File.Exists(gmdir))
                return true;
            return false;
        }

        public static bool IsGamemodeConfigExist(string gamemode)
        {
            string gmcfgdir = string.Format("Servers/{0}/SDG3R/Gamemodes/{1}/{1}.config", Dedicator.serverID, gamemode);
            if (File.Exists(gmcfgdir))
                return true;
            return false;
        }

        public static void UnloadCurrent()
        {
            Server.ServerData.CurrentMode.Unload();
            Server.ServerData.CurrentMode = null;
            GameObject.Destroy(Server.GamemodesObj);
            Server.GamemodesObj = new GameObject();
            GameObject.DontDestroyOnLoad(Server.GamemodesObj);
        }

        public static bool StartGamemodeByName(string name)
        {
            string gmdir = string.Format("Servers/{0}/SDG3R/Gamemodes/{1}/{1}.dll", Dedicator.serverID, name);
            string gmcfgdir = string.Format("Servers/{0}/SDG3R/Gamemodes/{1}/{1}.config", Dedicator.serverID, name);
            if (!IsGamemodeExist(name))
            {
                IConsole.SendConsole($"Gamemode '{name}' is missing!", ConsoleColor.Red);
                return false;
            }

            if (!IsGamemodeConfigExist(name))
            {
                IConsole.SendConsole($"Config for '{name}' is missing, Creating default config...", ConsoleColor.Yellow);
                File.WriteAllText(gmcfgdir, JsonConvert.SerializeObject(new SDG3RGamemodeData(name, Teams.Two, false, 25, 300, true, true), Formatting.Indented));
            }

            if (Server.ServerData.CurrentMode != null)
            {
                IConsole.SendConsole($"Unloading Gamemode: '{Server.ServerData.CurrentModeData.Gamemode}'", ConsoleColor.Yellow);
                UnloadCurrent();
            }

            try
            {
                IConsole.SendConsole($"Starting Gamemode: '{name}'...", ConsoleColor.Yellow);
                var a = Assembly.LoadFrom(gmdir);
                p = a.GetTypes().FirstOrDefault(x => x.IsSubclassOf(typeof(Gamemode)));
                if (p != null)
                {
                    var plugin = (Gamemode)Activator.CreateInstance(p);
                    plugin.Load();
                    Server.ServerData.CurrentMode = plugin;
                    Server.ServerData.CurrentModeData = JsonConvert.DeserializeObject<SDG3RGamemodeData>(File.ReadAllText(gmcfgdir));
                    IConsole.SendConsole($"Gamemode: '{name}' now running", ConsoleColor.Green);
                }
                else
                {
                    IConsole.SendConsole($"Error loading '{name}'", ConsoleColor.Red);
                    return false;
                }
            }
            catch (Exception ex)
            {
                IConsole.SendConsole($"Error loading '{name}'", ConsoleColor.Red);
                throw ex;
            }
            return true;
        }
    }
}
