using SDG.Unturned;
using SDG3R.Core.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using Random = UnityEngine.Random;

namespace SDG3R.Core.Data
{
    public class ScoreData
    {
        public List<Team> Teams = new List<Team>();
        public Teams TeamType;
        public int MaxScore;
        public Team Winner = null;
        public ScoreData(Teams TeamType, int MaxScore)
        {
            this.TeamType = TeamType;
            this.MaxScore = MaxScore;
            switch (TeamType)
            {
                case Classes.Teams.Two:
                    Teams.Add(new Team(new SerializableColor(0.04f, 0.643f, 1)));
                    Teams.Add(new Team(new SerializableColor(1, 0.361f, 0.04f)));
                    break;
            }
        }

        public void AddToBestTeam(SteamPlayer player)
        {
            if (GetTeamContaining(player) != null)
                return;
            switch (TeamType)
            {
                case Classes.Teams.FFA:
                    Color c = Random.ColorHSV(0f, 1f, 1f, 1f, 0.5f, 1f);
                    Teams.Add(new Team(new SerializableColor(c.r, c.g, c.b), new List<ulong>() { player.playerID.steamID.m_SteamID }));
                    break;
                case Classes.Teams.Two:
                    int LowestMembers = -1;
                    foreach (Team t in Teams)
                    {
                        if (LowestMembers == -1)
                        {
                            LowestMembers = t.Members.Count;
                            continue;
                        }
                        if (t.Members.Count == 0)
                        {
                            t.AddMember(player);
                            break;
                        }
                        if (t.Members.Count < LowestMembers)
                        {
                            t.AddMember(player);
                            break;
                        }
                    }
                    break;
            }
        }

        public void RemoveFromAnyTeam(SteamPlayer player)
        {
            foreach (Team t in Teams.ToList())
            {
                if (t.Members.Contains(player.playerID.steamID.m_SteamID))
                {
                    t.Members.Remove(player.playerID.steamID.m_SteamID);
                    if (TeamType == Classes.Teams.FFA)
                        Teams.Remove(t);
                }
            }
        }

        public void IncrementScore(SteamPlayer player, int Amount = 1)
        {
            foreach (Team t in Teams)
            {
                if (t.Members.Contains(player.playerID.steamID.m_SteamID))
                {
                    if (t.Score + Amount < 0)
                        return;
                    if (MaxScore > 0)
                        t.Score += Amount;
                    else if (t.Score < MaxScore)
                        t.Score += Amount;
                    if (t.Score == MaxScore)
                        Winner = t;
                    break;
                }
            }
        }

        public void IncrementScore(Team team, int Amount = 1)
        {
            if (team.Score + Amount < 0)
                return;
            if (MaxScore == -1)
                team.Score += Amount;
            else if (team.Score < MaxScore)
                team.Score += Amount;
            if (team.Score == MaxScore)
                Winner = team;
        }

        public Team GetBestEnemyTeam(SteamPlayer player)
        {
            Team BestTeam = null;

            foreach (Team t in Teams)
            {
                if (!t.Members.Contains(player.playerID.steamID.m_SteamID))
                {
                    if (BestTeam == null)
                    {
                        BestTeam = t;
                        continue;
                    }
                    if (BestTeam.Score < t.Score)
                        BestTeam = t;
                }
            }
            return BestTeam;
        }

        public Team GetWinningTeam()
        {
            Team BestTeam = null;

            foreach (Team t in Teams)
            {
                if (BestTeam == null)
                {
                    BestTeam = t;
                    continue;
                }
                if (BestTeam.Score < t.Score)
                    BestTeam = t;
            }
            return BestTeam;
        }

        public Team GetTeamContaining(SteamPlayer player)
        {
            foreach (Team t in Teams.Where(x => x.Members.Contains(player.playerID.steamID.m_SteamID)))
                return t;
            return null;
        }
        public Team GetTeamContaining(ulong player)
        {
            foreach (Team t in Teams.Where(x => x.Members.Contains(player)))
                return t;
            return null;
        }
    }

    public class Team
    {
        public List<ulong> Members = new List<ulong>();
        public int Score;
        public SerializableColor SColor;

        public Team(SerializableColor Color, List<ulong> Members = null, int Score = 0)
        {
            if (Members != null)
                this.Members = Members;
            this.Score = Score;
            this.SColor = Color;
        }
        public void AddMember(SteamPlayer player) => Members.Add(player.playerID.steamID.m_SteamID);
        public void RemoveMember(SteamPlayer player) => Members.Remove(player.playerID.steamID.m_SteamID);
    }
}
