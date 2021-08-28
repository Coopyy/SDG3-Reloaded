using Newtonsoft.Json;
using SDG.Framework.Modules;
using SDG3R.Core.Classes;
using SDG3R.Core.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SDG3R.Server
{
    public class Entry : IModuleNexus
    {
        public void initialize()
        {
            Console.Clear();
            IConsole.SendConsole("SDG3 Reloaded", ConsoleColor.Cyan);
            Utilities.Environment.Setup();
            IConsole.SendConsole("Preparing: " + Server.ServerData.GetGamemodeString(), ConsoleColor.Cyan);
        }


        public void shutdown()
        {
        }
    }
}
