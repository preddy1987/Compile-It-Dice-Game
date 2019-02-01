using CompileIt;
using System;
using System.Collections.Generic;
using System.Text;

namespace CompileIt
{
    public class CompileItPlayer : Player, ITurnStatus
    {
        private const int NumberDiePerRoll = 3;
        private const int MaxErrorCount = 3;
        private const int WinningSuccessCount = 13;

        private bool _turnOver = true;
        private List<Die> _lastWarningsDie = new List<Die>();
        private Cup _cup = new Cup();

        public int RoundCount { get; private set; }
        public int TotalSuccesses { get; private set; }
        public int TurnErrors { get; private set; }
        public int TurnSuccesses { get; private set; }
        public int TurnWarnings
        {
            get
            {
                return _lastWarningsDie.Count;
            }
        }
        public bool IsTurnOver
        {
            get
            {
                return TurnErrors >= MaxErrorCount || _turnOver;
            }
        }
        public bool IsWinner
        {
            get
            {
                return TotalSuccesses >= WinningSuccessCount;
            }
        }
        public double Odds
        {
            get
            {
                return 0.50;
            }
        }

        public CompileItPlayer(string name) : base(name)
        {
            ResetGame();
        }

        public void ResetGame()
        {
            ResetTurn();
            RoundCount = 1;
        }

        private void ResetTurn()
        {
            // Reset turn info
            TurnSuccesses = 0;
            TurnErrors = 0;
            _cup.Reset();
            _lastWarningsDie.Clear();
            _turnOver = false;
        }

        public void TakeRoll()
        {
            if (!IsWinner && !IsTurnOver)
            {
                // Collect the dice to roll
                List<Die> pulledDice = new List<Die>();
                for (int i = 0; i < (NumberDiePerRoll - _lastWarningsDie.Count); i++)
                {
                    pulledDice.Add(_cup.PullDie());
                }
                foreach (var die in _lastWarningsDie)
                {
                    pulledDice.Add(die);
                }
                _lastWarningsDie.Clear();

                // Roll the dice
                foreach (var die in pulledDice)
                {
                    var side = die.Roll();
                    if (side == CompileType.Error)
                    {
                        TurnErrors++;
                    }
                    else if (side == CompileType.Warning)
                    {
                        // Save the number of warnings rolled
                        _lastWarningsDie.Add(die);
                    }
                    else
                    {
                        TurnSuccesses++;
                    }
                }

                // Check to see if turn is already over
                if (IsTurnOver)
                {
                    TurnSuccesses = 0;
                    RoundCount++;
                }
            }
        }

        public void PassTurn()
        {
            if (!IsWinner && !IsTurnOver)
            {
                RoundCount++;
                TotalSuccesses += TurnSuccesses;
                ResetTurn();
            }
        }
    }
}
