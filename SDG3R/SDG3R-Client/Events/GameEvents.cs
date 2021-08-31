using Newtonsoft.Json;
using SDG3R.Client.Events.Delegates;
using SDG3R.Core.Classes;
using SDG3R.Core.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SDG3R.Client.Events
{
    public class GameEvents
    {
        public static event OnGameStateChangeHandler OnGameStateChange;
        public static event OnScoreboardChangeHandler OnScoreboardChange;
        public static event IncomingInfoHandler OnReceiveGameInfo;
        public static void DoIncomingInfoHandler(InfoType infoType, string value)
        {
            OnReceiveGameInfo?.Invoke(infoType, value);

            switch (infoType)
            {
                case InfoType.SetScoreBoard:
                    OnScoreboardChange?.Invoke(JsonConvert.DeserializeObject<TeamData>(value));
                    break;
                case InfoType.GameState:
                    OnGameStateChange?.Invoke(JsonConvert.DeserializeObject<GameStateData>(value));
                    break;
                default:
                    IConsole.SendConsole($"Invalid InfoType in communication: '{infoType}' carrying value '{value}'", ConsoleColor.Red);
                    break;
            }
        }
    }
}
