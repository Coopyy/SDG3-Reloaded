using SDG.Unturned;
using SDG3R.Client.Attributes;
using SDG3R.Client.Events;
using SDG3R.Client.Utilities;
using SDG3R.Core.Data;
using SDG3R.Core.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace SDG3R.Client.UI.Game
{
    [MonoComponent]
    public class KillFeedDisplay : MonoBehaviour
    {
        public static List<KillObject> Feed;
        void Start()
        {
            Feed = new List<KillObject>();
            GameEvents.OnPlayerDeath += OnPlayerDeath;
        }

        void OnGUI()
        {
            if (AssetUtilities.SDG3RSkin != null)
                GUI.skin = AssetUtilities.SDG3RSkin;

            GUI.BeginGroup(new Rect(Screen.width - 510, 10, 500, 500));
            foreach (KillObject KFObj in Feed.ToList())
            {
                if (KFObj.StartTimer + (KFObj.Timer - 1) <= Time.realtimeSinceStartup && (KFObj.Alpha - Time.deltaTime) >= 0)
                    KFObj.SetAlpha(KFObj.Alpha - Time.deltaTime);

                if (KFObj.StartTimer + KFObj.Timer <= Time.realtimeSinceStartup)
                    Feed.Remove(KFObj);

                GUI.color = new Color(1, 1, 1, KFObj.Alpha);
                GUILayout.Label($"<color=#{ColorToHex(KFObj.KillerColor, KFObj.Alpha)}>{KFObj.Killer}</color> [{KFObj.Weapon}] <color=#{ColorToHex(KFObj.PlayerColor, KFObj.Alpha)}>{KFObj.Player}</color>", style: "KillFeed", new GUILayoutOption[] { GUILayout.Width(500) });
                GUI.color = new Color(1, 1, 1, 1);

            }
            GUI.EndGroup();
        }



        public static void OnPlayerDeath(KillFeedData data)
        {
            SteamPlayer p = data.Player.FromSteamID();
            if (p == null)
                return;
            KillObject KObj = new KillObject(p.playerID.characterName, data.Cause, new Color(data.PlayerColor.r, data.PlayerColor.g, data.PlayerColor.b));
            if (data.Killer.HasValue)
            {
                SteamPlayer k = data.Killer.Value.FromSteamID();
                if (k != null)
                {
                    KObj.Killer = k.playerID.characterName;
                    if (KObj.KillerColor != null)
                        KObj.KillerColor = new Color(data.KillerColor.r, data.KillerColor.g, data.KillerColor.b);
                }
            }
            Feed.Add(KObj);
        }
        public class KillObject
        {
            public float StartTimer;
            public string Killer;
            public string Player;
            public string Weapon;
            public float Timer;
            public float Alpha;
            public Color PlayerColor;
            public Color KillerColor;
            public KillObject(string Player, string Weapon, Color PlayerColor, Color? KillerColor = null, string Killer = "World", float Alpha = 1, float Timer = 5f)
            {
                this.Killer = Killer;
                this.Player = Player;
                this.Weapon = Weapon;
                this.Timer = Timer;
                this.StartTimer = Time.realtimeSinceStartup;
                this.Alpha = Alpha;
                this.PlayerColor = PlayerColor;
                if (KillerColor.HasValue)
                    this.KillerColor = KillerColor.Value;
                else
                    this.KillerColor = Color.gray;
            }

            public void SetTimer(float newtime) =>
                Timer = newtime;

            public void SetAlpha(float alpha) =>
                Alpha = alpha;
        }
        private static string ColorToHex(Color32 color, float a)
        {
            string hex = color.r.ToString("X2") + color.g.ToString("X2") + color.b.ToString("X2") + ((byte)(a * 255)).ToString("X2");
            return hex;
        }
    }
}
