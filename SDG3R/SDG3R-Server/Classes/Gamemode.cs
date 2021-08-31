using Newtonsoft.Json;
using SDG.Unturned;
using SDG3R.Core.Classes;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace SDG3R.Server.Classes
{
    public class Gamemode
    {
        public GameStateData GameStateData;
        public SDG3RGamemodeData GamemodeData;
        public TeamData TeamData;

        public Gamemode()
        {

        }

        public void SetData(string name)
        {
            GamemodeData = JsonConvert.DeserializeObject<SDG3RGamemodeData>(File.ReadAllText(string.Format("Servers/{0}/SDG3R/Gamemodes/{1}/{1}.config", Dedicator.serverID, name)));
            GameStateData = new GameStateData(GamemodeData.TimeLimitInSeconds, GameState.WaitingForPlayers);
            TeamData = new TeamData(GamemodeData.Teams, GamemodeData.ScoreLimit);
        }

        public void AddComponent(Type t)
        {
            Server.GamemodesObj.AddComponent(t);
        }

        public void RemoveComponent(Type t)
        {
            UnityEngine.Object.Destroy(Server.GamemodesObj.GetComponent(t));
        }

        public string GetGamemodePath()
        {
            return string.Format("Servers/{0}/SDG3R/Gamemodes/{1}/", Dedicator.serverID, GamemodeData.Gamemode);
        }

        public virtual void Load()
        {

        }

        public virtual void Unload()
        {

        }

        ///<summary>
        ///called once before the game start. will then wait the configured amount of 'pregame time' until the GameLoop starts
        ///</summary>
        public virtual void OnPreGameStart()
        {

        }

        ///<summary>
        ///called once at game start, might want to 
        ///</summary>
        public virtual void OnGameStart()
        {

        }

        ///<summary>
        ///called once after the game ends 
        ///</summary>
        public virtual void OnPostGameStart()
        {

        }

        ///<summary>
        ///called once after the post game ends
        ///</summary>
        public virtual void OnPostGameEnd()
        {

        }
    }
}
