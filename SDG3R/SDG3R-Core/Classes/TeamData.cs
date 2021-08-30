using SDG.Unturned;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using Random = UnityEngine.Random;

namespace SDG3R.Core.Classes
{
    public class TeamData
    {
        public List<Team> Teams = new List<Team>();
        public Teams TeamType;
        public TeamData(Teams TeamType)
        {
            this.TeamType = TeamType;
            switch (TeamType)
            {
                case Classes.Teams.Two:
                    Teams.Add(new Team());
                    Teams.Add(new Team());
                    break;
                case Classes.Teams.Multi:
                    Teams.Add(new Team());
                    Teams.Add(new Team());
                    Teams.Add(new Team());
                    Teams.Add(new Team());
                    break;
            }
        }

        public void AddToBestTeam(SteamPlayer player)
        {
            switch (TeamType)
            {
                case Classes.Teams.FFA:
                    Teams.Add(new Team(new List<ulong>() { player.playerID.steamID.m_SteamID }));
                    break;
                case Classes.Teams.Two:
                case Classes.Teams.Multi:
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
            foreach (Team t in Teams)
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
                    t.Score += Amount;
                    break;
                }
            }
        }
    }

    public class Team
    {
        public List<ulong> Members = new List<ulong>();
        public int Score;
        public Team(List<ulong> Members = null, int Score = 0)
        {
            if (Members != null)
                this.Members = Members;
            this.Score = Score;
        }

        public void AddMember(SteamPlayer player) => Members.Add(player.playerID.steamID.m_SteamID);
        public void RemoveMember(SteamPlayer player) => Members.Remove(player.playerID.steamID.m_SteamID);
    }
}
