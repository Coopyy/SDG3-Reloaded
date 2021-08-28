using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SDG3R.Core.Classes
{
    public class SDG3RServerData
    {
        public string Gamemode; // Deathmatch, not Team Deathmatch
        public Teams Teams;
        public bool UseLoadouts;

        public SDG3RServerData(string Gamemode, Teams Teams, bool UseLoadouts)
        {
            this.Gamemode = Gamemode;
            this.Teams = Teams;
            this.UseLoadouts = UseLoadouts;
        }

        public string GetGamemodeString() // Loadout Team Deathmatch
        {
            string s = "";
            if (UseLoadouts)
                s += "Loadout ";
            switch (Teams)
            {
                case Teams.FFA:
                    s += "Free For All ";
                    break;
                case Teams.Two:
                    s += "Team ";
                    break;
                case Teams.Multi:
                    s += "Multi-Team ";
                    break;
            }
            return s += Gamemode;
        }
    }
}
