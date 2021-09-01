using Newtonsoft.Json;
using SDG.Unturned;
using SDG3R.Core.Classes;
using SDG3R.Core.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SDG3R.Server.Utilities
{
    public class Communication
    {
        public static void SendAllClients(InfoType infoType, object data)
        {
            foreach (var players in Provider.clients)
                players.player.sendAchievementUnlocked((int)infoType + "!" + JsonConvert.SerializeObject(data));
        }
    }
}
