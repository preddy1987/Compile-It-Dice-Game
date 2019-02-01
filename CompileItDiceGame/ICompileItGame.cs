using System;
using System.Collections.Generic;
using System.Text;

namespace CompileIt
{
    public interface ICompileItGame
    {
        double Odds { get; }
        bool HasWinner { get; }
        ITurnStatus CurrentPlayerStatus { get; }
        bool IsTurnOver { get; }
        string CurrentPlayerName { get; }

        void Start(List<string> playerNames);
        ITurnStatus RollDice();
        string PassTurn();        
    }
}
