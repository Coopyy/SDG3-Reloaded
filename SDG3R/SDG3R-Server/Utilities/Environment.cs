using Newtonsoft.Json;
using SDG.Unturned;
using SDG3R.Core.Classes;
using SDG3R.Server.Classes;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SDG3R.Server.Utilities
{
    class Environment
    {
        public static void Setup()
        {
            string configdir = string.Format("Servers/{0}/SDG3R/Server.json", Dedicator.serverID);
            if (File.Exists(configdir))
                Server.ServerData = new SDG3RServerData(JsonConvert.DeserializeObject<ServerConfig>(File.ReadAllText(configdir)));
            else
            {
                Directory.CreateDirectory(string.Format("Servers/{0}/SDG3R/", Dedicator.serverID));
                Server.ServerData = new SDG3RServerData(new ServerConfig(new List<string>() { "Deathmatch" }));
                File.WriteAllText(configdir, JsonConvert.SerializeObject(Server.ServerData.ServerConfig, Formatting.Indented));
            }
            if (!Directory.Exists(string.Format("Servers/{0}/SDG3R/Gamemodes/", Dedicator.serverID)))
                Directory.CreateDirectory(string.Format("Servers/{0}/SDG3R/Gamemodes/", Dedicator.serverID));
        }
    }
}
