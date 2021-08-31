using Newtonsoft.Json;
using SDG3R.Client.Attributes;
using SDG3R.Client.Events;
using SDG3R.Core.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace SDG3R.Client.UI
{
    [MonoComponent]
    public class InGameUI : MonoBehaviour
    {
        void Start()
        {
            GameEvents.OnGameStateChange += OnGameStateChange;
            GameEvents.OnScoreboardChange += OnScoreboardChange;
        }

        private static string timeremaining = "00:00";
        private static string gamestate = "";
        private static TeamData tteamData = null;

        void OnGUI()
        {
            GUILayout.Box(timeremaining);
            GUILayout.Box(gamestate);
            
            if (tteamData != null)
            {
                foreach (Team item in tteamData.Teams)
                {
                    GUILayout.Box(item.Score.ToString());
                    foreach (ulong t in item.Members)
                    {
                        GUILayout.Box(t.ToString());
                    }
                }
            }
        }

        public static void OnScoreboardChange(TeamData teamData)
        {
            tteamData = teamData;
        }

        public static void OnGameStateChange(GameStateData data)
        {
            timeremaining = TimeSpan.FromSeconds(data.TimeRemaining).ToString(@"mm\:ss");
            gamestate = Enum.GetName(typeof(GameState), data.GameState);
        }

    }
}
