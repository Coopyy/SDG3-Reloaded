using Newtonsoft.Json;
using SDG.Unturned;
using SDG3R.Core.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SDG3R.Server.Utilities
{
    public class Communication
    {
        public static void BroadcastRawData(InfoType infoType, string data)
        {
            foreach (var players in Provider.clients)
                players.player.sendAchievementUnlocked((int)infoType + "!" + data);
        }

        public static void UpdateClientScoreboard(TeamData TeamData)
        {
            BroadcastRawData(InfoType.SetScoreBoard, JsonConvert.SerializeObject(TeamData));
        }

        public static void UpdateClientGameState(GameStateData GameState)
        {
            BroadcastRawData(InfoType.GameState, JsonConvert.SerializeObject(GameState));
        }
    }
}
