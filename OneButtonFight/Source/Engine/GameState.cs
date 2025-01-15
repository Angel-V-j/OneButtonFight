using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OneButtonFight.Source.Engine
{
    public enum GameState
    {
        Empty = 0,
        Loaded = 1,
        Running = 2,
        Paused = 3,
        GameOver = 4,
        Completed = 5
    }
}
