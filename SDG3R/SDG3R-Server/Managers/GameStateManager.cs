using SDG.Unturned;
using SDG3R.Core.Classes;
using SDG3R.Server.Utilities;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace SDG3R.Server.Managers
{
    public class GameStateManager : MonoBehaviour
    {
        public void Start()
        {
            StartCoroutine(WaitingForPlayers());
        }

        IEnumerator WaitingForPlayers()
        {
            Server.ServerData.CurrentMode.GameStateData.TimeRemaining = 0;
            Server.ServerData.CurrentMode.GameStateData.GameState = Core.Classes.GameState.WaitingForPlayers;
            while (Provider.clients.Count < Server.ServerData.CurrentMode.GamemodeData.MininumPlayersToStart)
            {
                yield return new WaitForSecondsRealtime(1f);
            }
            StartCoroutine(PreGame());
        }

        IEnumerator PreGame()
        {
            Server.ServerData.CurrentMode.OnPreGameStart();
            Server.ServerData.CurrentMode.GameStateData.TimeRemaining = 15;
            Server.ServerData.CurrentMode.GameStateData.GameState = Core.Classes.GameState.PreGame;
            while (Server.ServerData.CurrentMode.GameStateData.GameState == Core.Classes.GameState.PreGame && Server.ServerData.CurrentMode.GameStateData.TimeRemaining > 0)
            {
                Communication.SendAllClients(InfoType.GameState, Server.ServerData.CurrentMode.GameStateData);
                Server.ServerData.CurrentMode.GameStateData.TimeRemaining--;
                yield return new WaitForSecondsRealtime(1f);
            }
            StartCoroutine(InGameLoop());
        }

        IEnumerator InGameLoop()
        {
            Server.ServerData.CurrentMode.OnGameStart();
            Server.ServerData.CurrentMode.GameStateData.TimeRemaining = Server.ServerData.CurrentMode.GamemodeData.TimeLimitInSeconds;
            Server.ServerData.CurrentMode.GameStateData.GameState = Core.Classes.GameState.InGame;
            while (Server.ServerData.CurrentMode.GameStateData.GameState == Core.Classes.GameState.InGame && (Server.ServerData.CurrentMode.GameStateData.TimeRemaining > 0 || Server.ServerData.CurrentMode.GamemodeData.TimeLimitInSeconds == -1) && Server.ServerData.CurrentMode.TeamData.Winner == null) // or score reached
            {
                Communication.SendAllClients(InfoType.GameState, Server.ServerData.CurrentMode.GameStateData);
                Server.ServerData.CurrentMode.GameStateData.TimeRemaining--;
                yield return new WaitForSecondsRealtime(1f);
            }
            StartCoroutine(PostGame());
        }

        IEnumerator PostGame()
        {
            Server.ServerData.CurrentMode.OnPostGameStart();
            Server.ServerData.CurrentMode.GameStateData.TimeRemaining = 10;
            Server.ServerData.CurrentMode.GameStateData.GameState = Core.Classes.GameState.PostGame;
            while (Server.ServerData.CurrentMode.GameStateData.GameState == Core.Classes.GameState.PostGame && Server.ServerData.CurrentMode.GameStateData.TimeRemaining > 0)
            {
                Communication.SendAllClients(InfoType.GameState, Server.ServerData.CurrentMode.GameStateData);
                Server.ServerData.CurrentMode.GameStateData.TimeRemaining--;
                yield return new WaitForSecondsRealtime(1f);
            }
            Server.ServerData.TrySwitchGamemode();
        }
    }
}
