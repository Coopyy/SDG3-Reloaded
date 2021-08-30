using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SDG3R.Core.Classes
{
    public class GameStateData
    {
        public int TimeRemaining;
        public GameState GameState;

        public GameStateData(int TimeRemaining, GameState GameState)
        {
            this.TimeRemaining = TimeRemaining;
            this.GameState = GameState;
        }
    }
}
