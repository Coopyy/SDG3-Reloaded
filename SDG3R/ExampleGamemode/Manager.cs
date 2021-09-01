using SDG.Unturned;
using SDG3R.Core.Classes;
using SDG3R.Core.Logging;
using SDG3R.Server.Classes;
using SDG3R.Server.Utilities;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace ExampleGamemode
{
    public class Manager : MonoBehaviour
    {
        public void Start()
        {
            StartCoroutine(yea());
        }

        IEnumerator yea()
        {
            while (true)
            {
                foreach (var item in Loader.instance.TeamData.Teams)
                {
                    Loader.instance.TeamData.IncrementScore(item);
                    Communication.SendAllClients(InfoType.SetScoreBoard, Loader.instance.TeamData);
                }
                yield return new WaitForSeconds(5f);
            }
        }
    }
}