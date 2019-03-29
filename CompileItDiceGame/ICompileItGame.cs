using System;
using System.Collections.Generic;
using System.Text;

namespace CompileIt
{
    public interface ICompileItGame
    {
        double Odds { get; }
        bool HasWinner { get; }
        bool IsLastRound { get; }
        ITurnStatus CurrentPlayerStatus { get; }
        List<IPlayerStatus> PlayersStatus { get; }
        List<IPlayerName> Players { get; }
        bool IsTurnOver { get; }
        string CurrentPlayerName { get; }

        void Start();
        ITurnStatus RollDice();
        string PassTurn();
        void SaveWinner(string playerName);
        void AddPlayer(string playerName);
        void RemovePlayer(string playerName);
        void RemoveAllPlayers();
    }
}
