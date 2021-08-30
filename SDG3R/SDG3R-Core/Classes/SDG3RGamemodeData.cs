using SDG.Unturned;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SDG3R.Core.Classes
{
    public class SDG3RGamemodeData
    {
        public string Gamemode; // Deathmatch, not Team Deathmatch
        public Teams Teams;
        public bool UseLoadouts;
        public bool DisplayScore;
        public bool DisplayTimeLimit;
        public int ScoreLimit; // -1 if infinite
        public int TimeLimitInSeconds; // -1 if infinite
        //public List<string> MapRotation;

        public SDG3RGamemodeData(string Gamemode, Teams Teams, bool UseLoadouts, int ScoreLimit, int TimeLimitInSeconds, bool DisplayScore, bool DisplayTimeLimit)
        {
            this.Gamemode = Gamemode;
            this.Teams = Teams;
            this.UseLoadouts = UseLoadouts;
            this.TimeLimitInSeconds = TimeLimitInSeconds;
            this.ScoreLimit = ScoreLimit;
            this.DisplayScore = DisplayScore;
            this.DisplayTimeLimit = DisplayTimeLimit;
            
        }

        public string GetGamemodeString() // Loadout Team Deathmatch on Alpha Valley
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
            //return s += $"{Gamemode} on {Provider.currentServerInfo.map}";
            return s += $"{Gamemode}";
        }
    }
}
