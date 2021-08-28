using Newtonsoft.Json;
using SDG.Unturned;
using SDG3R.Core.Classes;
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
                Server.ServerData = JsonConvert.DeserializeObject<SDG3RServerData>(File.ReadAllText(configdir));
            else
            {
                Directory.CreateDirectory(string.Format("Servers/{0}/SDG3R/", Dedicator.serverID));
                File.WriteAllText(configdir, JsonConvert.SerializeObject(Server.ServerData = new SDG3RServerData("Deathmatch", Teams.Two, true), Formatting.Indented));
            }
        }
    }
}
