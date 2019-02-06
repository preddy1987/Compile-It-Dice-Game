using System;
using System.Collections.Generic;
using System.Text;

namespace CompileIt
{
    public interface IPlayerStatus
    {
        string Name { get; }
        int RoundCount { get; }
        int TotalSuccesses { get; }
    }

    public interface ITurnStatus : IPlayerStatus
    {
        int TurnErrors { get; }
        int TurnSuccesses { get; }
        int TurnWarnings { get; }
        double Odds { get; }
        List<Die> RemainingDice { get; }
    }
}
