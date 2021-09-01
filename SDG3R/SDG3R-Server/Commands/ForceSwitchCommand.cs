using SDG.Unturned;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SDG3R.Server.Commands
{
    public class ForceSwitchCommand : Command
    {
        public ForceSwitchCommand()
        {
            localization = new Local();
            _command = "fs";
            _info = _command;
            _help = "Switches Gamemode";
        }

        protected override void execute(Steamworks.CSteamID executorID, string parameter)
        {
            Server.ServerData.TrySwitchGamemode();
        }
    }
}
