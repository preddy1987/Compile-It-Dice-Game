using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CompileIt
{
    public class GameStatus
    {
        public bool IsLastRound { get; set; }
        public bool HasWinner { get; set; }
        public string CurrentPlayer { get; set; }
        public bool IsTurnOver { get; set; }      
        public bool IsGameActive { get; set; }
    }
}
