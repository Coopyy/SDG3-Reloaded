using HarmonyLib;
using SDG.Unturned;
using SDG3R.Client.Events;
using SDG3R.Client.Events.Delegates;
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
            string[] arg = id.Split(new[] { '!' }, 2);
            if (!int.TryParse(arg[0], out int o))
                return false;
            InfoType infoType = (InfoType)o;
            string value = arg[1];
            GameEvents.DoIncomingInfoHandler(infoType, value);
            return false;
        }
    }
}
