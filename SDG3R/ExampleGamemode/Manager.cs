using SDG.Unturned;
using SDG3R.Core.Classes;
using SDG3R.Core.Logging;
using SDG3R.Server.Classes;
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
        int seconds = 300;
        int score = 0;
        public void Start()
        {
            StartCoroutine(yea());
        }

        IEnumerator yea()
        {
            while (true)
            {
                foreach (var item in Provider.clients)
                {
                    IConsole.SendConsole("Updating Client");
                    item.player.sendAchievementUnlocked((int)InfoType.TimeRemaining + "!" + seconds);
                    item.player.sendAchievementUnlocked((int)InfoType.SetScoreBoard + "!" + score);
                    IConsole.SendConsole("Done");
                }
                seconds--;
                score++;
                yield return new WaitForSeconds(1f);
            }
        }
    }
}
