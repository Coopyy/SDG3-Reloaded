using SDG3R.Core.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SDG3R.Client.Events.Delegates
{
    public delegate void IncomingInfoHandler(InfoType infoType, string value);
    public delegate void OnScoreboardChangeHandler(int yourteam, int second, int maxvalue);
    public delegate void OnTimerChangeHandler(int seconds);
}
