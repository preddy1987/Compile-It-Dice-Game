using CompileIt;
using System;
using System.Collections.Generic;
using System.Text;

namespace CompileItDiceGame.Models
{
    [Serializable]
    public class PlayerScore
    {     
        public string PlayerName { get; set; }
        public int NumOfWins { get; set; }

    }
}
