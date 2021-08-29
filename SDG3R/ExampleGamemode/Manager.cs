using SDG3R.Core.Logging;
using SDG3R.Server.Classes;
using System;
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
            IConsole.SendConsole("started from unity function start!");
        }

        public void Update()
        {
            IConsole.SendConsole("started from unity function update!");
        }
    }
}
