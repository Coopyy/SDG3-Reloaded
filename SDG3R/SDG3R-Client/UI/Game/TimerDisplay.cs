using Newtonsoft.Json;
using SDG.Unturned;
using SDG3R.Client.Attributes;
using SDG3R.Client.Events;
using SDG3R.Client.Utilities;
using SDG3R.Core.Classes;
using SDG3R.Core.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace SDG3R.Client.UI.Game
{
    [MonoComponent]
    public class TimerDisplay : MonoBehaviour
    {
        private static string TimeRemainingString = "00:00";
        void Start()
        {
            GameEvents.OnGameStateChange += OnGameStateChange;
        }

        void OnGUI()
        {
            if (AssetUtilities.SDG3RSkin != null)
                GUI.skin = AssetUtilities.SDG3RSkin;

            GUI.Box(new Rect((Screen.width / 2) - 40, 10, 80, 20), TimeRemainingString, style: "TimerBG");
        }

        public static void OnGameStateChange(GameStateData data)
        {
            TimeRemainingString = TimeSpan.FromSeconds(data.TimeRemaining).ToString(@"mm\:ss");
            //gamestate = Enum.GetName(typeof(GameState), data.GameState);
        }
    }
}
