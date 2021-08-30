using SDG3R.Client.Attributes;
using SDG3R.Client.Events;
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
            GameEvents.OnScoreboardChange += ScoreboardChanged;
            GameEvents.OnTimerChange += TimeRemainingChanged;
        }

        private static string timeremaining = "00:00";
        private static int team1 = 0;
        private static int team2 = 0;
        private static int maxscore = 0;

        void OnGUI()
        {
            GUILayout.Box(timeremaining);
            GUILayout.Box($"Your Score: {team1}/{maxscore}");
            GUILayout.Box($"Enemy Score: {team2}/{maxscore}");
        }

        public static void ScoreboardChanged(int yourteam, int secondslot, int max)
        {
            team1 = yourteam;
            team2 = secondslot;
            maxscore = max;
        }

        public static void TimeRemainingChanged(int value) => timeremaining = TimeSpan.FromSeconds(value).ToString(@"mm\:ss");
    }
}
