using SDG.Unturned;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SDG3R.Core.Extensions
{
    public static class SteamPlayerExtensions
    {
        public static SteamPlayer FromSteamID(this ulong id)
        {
            foreach (var user in Provider.clients)
            {
                if (user.playerID.steamID.m_SteamID == id)
                    return user;
            }

            return null;
        }
    }
}
