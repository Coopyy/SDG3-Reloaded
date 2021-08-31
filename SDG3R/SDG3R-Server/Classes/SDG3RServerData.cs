using Newtonsoft.Json;
using SDG.Unturned;
using SDG3R.Core.Classes;
using SDG3R.Core.Logging;
using SDG3R.Server.Utilities;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SDG3R.Server.Classes
{
    public class SDG3RServerData
    {
        public ServerConfig ServerConfig;
        public Gamemode CurrentMode = null;
        public SDG3RServerData(ServerConfig ServerConfig)  // new server, only called once
        {
            this.ServerConfig = ServerConfig;
        }

        public void TrySwitchGamemode()
        {
            try
            {
                string gm = "";
                if (ServerConfig.Gamemodes.Count == 0)
                {
                    IConsole.SendConsole("You have no gamemodes listed to choose from! Generating default list...", ConsoleColor.Red);
                    File.WriteAllText(string.Format("Servers/{0}/SDG3R/Server.json", Dedicator.serverID), JsonConvert.SerializeObject(Server.ServerData = new SDG3RServerData(new ServerConfig(new List<string>() { "Deathmatch" })), Formatting.Indented));
                }
                if (ServerConfig.Gamemodes.Count == 1)
                    gm = ServerConfig.Gamemodes.First();
                else if (ServerConfig.Gamemodes.Count > 1)
                {
                    Random rnd = new Random();
                    gm = ServerConfig.Gamemodes.OrderBy(x => rnd.Next()).Take(1).First();
                    if (CurrentMode?.GamemodeData?.Gamemode != null)
                        while (gm == CurrentMode.GamemodeData.Gamemode) // dont choose gamemode thats already running
                            gm = ServerConfig.Gamemodes.OrderBy(x => rnd.Next()).Take(1).First();
                }

                if (!GamemodeUtilities.StartGamemodeByName(gm))
                    IConsole.SendConsole($"Failed to load '{gm}'. Currently running no gamemodes", ConsoleColor.Red);
            }
            catch (Exception ex)
            {
                IConsole.SendConsole(ex.ToString(), ConsoleColor.Red);
                throw;
            }
        }
    }
}
