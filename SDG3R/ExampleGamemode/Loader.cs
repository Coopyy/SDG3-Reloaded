using SDG.Unturned;
using SDG3R.Core.Logging;
using SDG3R.Server;
using SDG3R.Server.Classes;
using SDG3R.Server.Utilities;
using Steamworks;
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
        public static Loader instance;
        public override void Load()
        {
            instance = this;
            IConsole.SendConsole("ExampleGamemode Loaded!");

            Provider.onEnemyConnected += onEnemyConnected;
            Provider.onEnemyDisconnected += onEnemyDisconnected;

            AddComponent(typeof(Manager));

        }

        public void onEnemyConnected(SteamPlayer player)
        {
            if (instance.GameStateData.GameState == SDG3R.Core.Classes.GameState.InGame)
                instance.TeamData.AddToBestTeam(player);
        }

        public void onEnemyDisconnected(SteamPlayer player)
        {
            instance.TeamData.RemoveFromAnyTeam(player);
        }

        public override void OnPreGameStart()
        {
            IConsole.SendConsole("OnPreGameStart called");
        }

        public override void OnGameStart()
        {
            foreach (var item in Provider.clients)
            {
                instance.TeamData.AddToBestTeam(item);
            }
            IConsole.SendConsole("OnGameStart called");
        }

        public override void OnPostGameStart()
        {
            IConsole.SendConsole("OnPostGameStart called");
        }

        public override void OnPostGameEnd()
        {
            IConsole.SendConsole("OnPostGameEnd called");
        }
    }
}
