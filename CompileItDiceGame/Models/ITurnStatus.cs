using System;
using System.Collections.Generic;
using System.Text;

namespace CompileIt
{
    public interface IPlayerName
    {
        string Name { get; }
    }

    public interface IPlayerStatus : IPlayerName
    {
        int RoundCount { get; }
        int TotalSuccesses { get; }
    }

    public interface ITurnStatus : IPlayerStatus
    {
        int TurnErrors { get; }
        int TurnSuccesses { get; }
        int TurnWarnings { get; }
        double Odds { get; }
        List<string> RemainingDice { get; }
    }

    public interface IRollStatus : ITurnStatus
    {
        List<RollInfo> RollSides { get; }
    }
}
