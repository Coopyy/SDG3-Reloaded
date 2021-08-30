using SDG3R.Client.Attributes;
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
        public static int timeremaining = 0;
        public static int scoreboard = 0;
        void OnGUI()
        {
            GUILayout.Box(TimeSpan.FromSeconds(timeremaining).ToString(@"mm\:ss"));
            GUILayout.Box("Score: " + scoreboard.ToString());
        }
    }
}
