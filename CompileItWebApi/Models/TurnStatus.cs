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
        public List<RollInfo> DieSides { get; set; } = new List<RollInfo>();
        public List<RollInfo> RemainingDice { get; set; }
        public List<RollInfo> ErrorSides { get; set; } = new List<RollInfo>();
        public List<RollInfo> SuccessSides { get; set; } = new List<RollInfo>();

        public TurnStatus(ITurnStatus status)
        {
            TurnErrors = status.TurnErrors;
            TurnSuccesses = status.TurnSuccesses;
            TurnWarnings = status.TurnWarnings;
            Odds = status.Odds.ToString("N2");
            RoundCount = status.RoundCount;
            TotalSuccesses = status.TotalSuccesses;
            ErrorSides = status.ErrorSides;
            SuccessSides = status.SuccessSides;
            DieSides = status.RollSides;

            RemainingDice = status.RemainingDice;
        }
    }
}
