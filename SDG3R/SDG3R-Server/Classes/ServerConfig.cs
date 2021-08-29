using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SDG3R.Server.Classes
{
    public class ServerConfig
    {
        public List<string> Gamemodes;
        public ServerConfig(List<string> Gamemodes)
        {
            this.Gamemodes = Gamemodes;
        }
    }
}
