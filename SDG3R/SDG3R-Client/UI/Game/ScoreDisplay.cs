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
    public class ScoreDisplay : MonoBehaviour
    {
        private static ScoreData Score = null;
        private static Team MyTeam = null;
        private static Team BestEnemyTeam = null;
        void Start()
        {
            GameEvents.OnScoreboardChange += OnScoreboardChange;
        }

        void OnGUI()
        {
            if (AssetUtilities.SDG3RSkin != null)
                GUI.skin = AssetUtilities.SDG3RSkin;

            if (Score == null)
                return;
            if (MyTeam == null)
                return;
            #region Left Score
            int LeftWidth = (Screen.width / 10);
            if (Score.MaxScore > 0)
                LeftWidth = (int)((Screen.width / 10) * ((float)MyTeam.Score / (float)Score.MaxScore));
            GUI.Box(new Rect((Screen.width / 2) - 50 - (Screen.width / 10), 10, (Screen.width / 10), 20), "", style: "ScoreBGLeft");
            UIUtilities.DrawColor(new Rect((Screen.width / 2) - 50 - LeftWidth, 10, LeftWidth, 20), new Color(MyTeam.SColor.r, MyTeam.SColor.g, MyTeam.SColor.b, .9f));
            GUI.Label(new Rect((Screen.width / 2) - 50 - (Screen.width / 10), 10, (Screen.width / 10), 20), MyTeam.Score.ToString(), style: "ScoreLeft");
            #endregion

            if (BestEnemyTeam == null)
                return;

            #region Right Score
            int RightWidth = (Screen.width / 10);
            if (Score.MaxScore > 0)
                RightWidth = (int)((Screen.width / 10) * ((float)BestEnemyTeam.Score / (float)Score.MaxScore));
            GUI.Box(new Rect((Screen.width / 2) + 50, 10, (Screen.width / 10), 20), "", style: "ScoreBGRight");
            UIUtilities.DrawColor(new Rect((Screen.width / 2) + 50, 10, RightWidth, 20), new Color(BestEnemyTeam.SColor.r, BestEnemyTeam.SColor.g, BestEnemyTeam.SColor.b, .9f));
            GUI.Label(new Rect((Screen.width / 2) + 50, 10, (Screen.width / 10), 20), BestEnemyTeam.Score.ToString(), style: "ScoreRight");
            #endregion
        }

        public static void OnScoreboardChange(ScoreData scoredata)
        {
            Score = scoredata;
            BestEnemyTeam = scoredata.GetBestEnemyTeam(Player.player.channel.owner);
            MyTeam = scoredata.GetTeamContaining(Player.player.channel.owner);
        }
    }
}
