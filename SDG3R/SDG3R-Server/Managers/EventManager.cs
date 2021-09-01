using SDG.Unturned;
using SDG3R.Core.Classes;
using SDG3R.Core.Data;
using SDG3R.Server.Utilities;
using Steamworks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace SDG3R.Server.Managers
{
    public class EventManager : MonoBehaviour
    {
        void Start()
        {
            PlayerLife.onPlayerDied += PlayerLife_onPlayerDied;
        }

        private void PlayerLife_onPlayerDied(PlayerLife sender, EDeathCause cause, ELimb limb, CSteamID instigator)
        {
            KillFeedData killData = new KillFeedData();
            killData.Player = sender.channel.owner.playerID.steamID.m_SteamID;
            Team PTeam = Server.ServerData.CurrentMode.TeamData.GetTeamContaining(sender.channel.owner.playerID.steamID.m_SteamID);
            if (PTeam != null)
                killData.PlayerColor = PTeam.SColor;
            else
                killData.PlayerColor = new SerializableColor(1, 1, 1);
            if (instigator != CSteamID.Nil)
            {
                Team KTeam = Server.ServerData.CurrentMode.TeamData.GetTeamContaining(instigator.m_SteamID);
                if (KTeam != null)
                    killData.KillerColor = KTeam.SColor;
                else
                    killData.KillerColor = new SerializableColor(1, 1, 1);
                killData.Killer = instigator.m_SteamID;
            }
            switch (cause)
            {
                case EDeathCause.GUN:
                case EDeathCause.MELEE:
                    killData.Cause = sender.player.equipment.asset.itemName.ToString();
                    break;
                default:
                    string ec = Enum.GetName(typeof(EDeathCause), cause).ToLower();
                    killData.Cause = char.ToUpper(ec[0]) + ec.Substring(1);
                    break;
            }
            Communication.SendAllClients(InfoType.PlayerDeath, killData);
        }
    }
}
