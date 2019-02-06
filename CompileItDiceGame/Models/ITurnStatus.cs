using System;
using System.Collections.Generic;
using System.Text;

namespace CompileIt
{
    public interface ITurnStatus
    {
        int RoundCount { get; }
        int TotalSuccesses { get; }
        int TurnErrors { get; }
        int TurnSuccesses { get; }
        int TurnWarnings { get; }
        double Odds { get; }
        List<Die> RemainingDice { get; }
    }
}
