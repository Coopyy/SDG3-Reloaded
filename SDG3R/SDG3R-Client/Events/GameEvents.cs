using SDG3R.Client.Events.Delegates;
using SDG3R.Core.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SDG3R.Client.Events
{
    public class GameEvents
    {
        public static event OnTimerChangeHandler OnTimerChange;
        public static event OnScoreboardChangeHandler OnScoreboardChange;
        public static event IncomingInfoHandler OnReceiveGameInfo;
        public static void DoIncomingInfoHandler(InfoType infoType, string value)
        {
            OnReceiveGameInfo?.Invoke(infoType, value);

            switch (infoType)
            {
                case InfoType.SetScoreBoard:
                    int[] vals = Array.ConvertAll(value.Split(','), int.Parse);
                    OnScoreboardChange?.Invoke(vals[0], vals[1], vals[2]);
                    break;
                case InfoType.TimeRemaining:
                    OnTimerChange?.Invoke(int.Parse(value));
                    break;
                default:
                    break;
            }
        }
    }
}
