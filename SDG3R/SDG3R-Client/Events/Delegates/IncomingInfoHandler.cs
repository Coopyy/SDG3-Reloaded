using SDG3R.Core.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SDG3R.Client.Events.Delegates
{
    public delegate void IncomingInfoHandler(InfoType infoType, string value);
    public delegate void OnScoreboardChangeHandler(TeamData TeamData);
    public delegate void OnGameStateChangeHandler(GameStateData GameStateData);
}
