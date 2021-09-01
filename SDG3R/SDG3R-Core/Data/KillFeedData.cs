using SDG3R.Core.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SDG3R.Core.Data
{
    public class KillFeedData
    {
        public ulong Player;
        public ulong? Killer = null;
        public SerializableColor PlayerColor;
        public SerializableColor KillerColor = null;
        public string Cause;

        public KillFeedData()
        {
        }
    }
}
