using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CompileIt
{
    public class TurnStatus
    {
        public int TurnErrors { get; set; }
        public int TurnSuccesses { get; set; }
        public int TurnWarnings { get; set; }
        public string Odds { get; set; }
        public int RoundCount { get; set; }
        public int TotalSuccesses { get; set; }

        public List<Die> RemainingDice { get; set; }

        public TurnStatus(ITurnStatus status)
        {
            TurnErrors = status.TurnErrors;
            TurnSuccesses = status.TurnSuccesses;
            TurnWarnings = status.TurnWarnings;
            Odds = status.Odds.ToString("N2");
            RoundCount = status.RoundCount;
            TotalSuccesses = status.TotalSuccesses;

            RemainingDice = status.RemainingDice;
        }
    }
}
