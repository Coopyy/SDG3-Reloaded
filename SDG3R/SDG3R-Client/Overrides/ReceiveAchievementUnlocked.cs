using HarmonyLib;
using SDG.Unturned;
using SDG3R.Client.UI;
using SDG3R.Core.Classes;
using SDG3R.Core.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SDG3R.Client.Overrides
{
    [HarmonyPatch(typeof(Player))]
    [HarmonyPatch("ReceiveAchievementUnlocked")]
    public class ReceiveAchievementUnlocked
    {
        public static bool Prefix(string id)
        {
            IConsole.SendConsole($"Incoming Raw: {id}" , ConsoleColor.Green);
            string[] arg = id.Split(new[] { '!' }, 2);

            if (!int.TryParse(arg[0], out int o))
                return false;
            InfoType infoType = (InfoType)o;
            string value = arg[1];
            IConsole.SendConsole($"From Server: Type '{Enum.GetName(typeof(InfoType), infoType)}' Value '{value}'" , ConsoleColor.DarkBlue);
            switch (infoType)
            {
                case InfoType.SetScoreBoard:
                    InGameUI.scoreboard = int.Parse(value);
                    break;
                case InfoType.TimeRemaining:
                    InGameUI.timeremaining = int.Parse(value);
                    break;
                default:
                    break;
            }

            return false;
        }
    }
}
