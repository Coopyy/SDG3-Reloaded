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
        public GameStateData GameState;
        public SDG3RGamemodeData GamemodeData;
        public TeamData TeamData;

        public Gamemode()
        {
            
        }

        public void SetData(string name)
        {
            GamemodeData = JsonConvert.DeserializeObject<SDG3RGamemodeData>(File.ReadAllText(string.Format("Servers/{0}/SDG3R/Gamemodes/{1}/{1}.global.config", Dedicator.serverID, name)));
            GameState = new GameStateData(GamemodeData.TimeLimitInSeconds, Core.Classes.GameState.WaitingForPlayers);
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

        public void EndGame()
        {
            GameState.GameState = Core.Classes.GameState.PostGame;
            GameEnd();
        }

        public virtual void Load()
        {

        }

        public virtual void Unload()
        {

        }

        ///<summary>
        ///called ONCE before the game start. will then wait the configured amount of 'pregame time' until the GameLoop starts
        ///</summary>
        public virtual void PreGameStart()
        {

        }

        ///<summary>
        ///called ONCE at game start, might want to 
        ///</summary>
        public virtual void GameStart()
        {

        }

        ///<summary>
        ///called ONCE at game start, might want to 
        ///</summary>
        public virtual void GameEnd()
        {

        }
    }
}
