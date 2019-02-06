using System;
using System.Collections.Generic;

namespace CompileIt
{
    public class CompileItGame : ICompileItGame
    {
        #region Member Variables
        private List<CompileItPlayer> _players = null;

        private int _currentPlayerIndex = 0;
        private int _startPlayerIndex = 0;
        #endregion

        #region Properties
        public string CurrentPlayerName
        {
            get
            {
                return CurrentPlayer.Name;
            }
        }

        public bool HasWinner
        {
            get
            {
                bool hasWinner = false;
                CompileItPlayer winner = GetCurrentWinner();
                if(winner != null)
                {
                    hasWinner = true;

                    // Check to see if all players finished their last turn
                    foreach (var player in _players)
                    {
                        if (player.RoundCount != winner.RoundCount)
                        {
                            hasWinner = false;
                        }
                    }
                }

                return hasWinner;
            }
        }

        public bool IsLastRound
        {
            get
            {
                return GetCurrentWinner() != null;
            }
        }

        private CompileItPlayer GetCurrentWinner()
        {
            CompileItPlayer winner = null;
            foreach (var player in _players)
            {
                if (player.IsWinner)
                {
                    if (winner == null || (winner != null && winner.TotalSuccesses < player.TotalSuccesses))
                    {
                        winner = player;
                    }
                }
            }
            return winner;
        }

        public string WinnerName
        {
            get
            {
                string winner = null;
                foreach (var player in _players)
                {
                    if (player.IsWinner)
                    {
                        winner = player.Name;
                    }
                }
                if(winner == null)
                {
                    throw new Exception("There is no winner yet.");
                }
                return winner;
            }
        }

        private CompileItPlayer CurrentPlayer
        {
            get
            {
                return _players[_currentPlayerIndex];
            }
        }

        public double Odds
        {
            get
            {
                return CurrentPlayer.Odds;
            }
        }

        public ITurnStatus CurrentPlayerStatus
        {
            get
            {
                return CurrentPlayer;
            }
        }

        public bool IsTurnOver
        {
            get
            {
                return CurrentPlayer.IsTurnOver;
            }
        }
        #endregion

        #region Constructors
        public CompileItGame()
        {

        }
        #endregion

        #region Methods
        public void Start(List<string> playerNames)
        {
            Random rnd = new Random();
            _startPlayerIndex = rnd.Next(0, playerNames.Count);

            SetupPlayers(playerNames);

            _currentPlayerIndex = _startPlayerIndex;
        }

        private void SetupPlayers(List<string> playerNames)
        {
            if (playerNames == null || playerNames.Count == 0)
            {
                throw new Exception("This game requires at least 1 player.");
            }

            if (_players != null)
            {
                _players.Clear();
            }
            else
            {
                _players = new List<CompileItPlayer>();
            }

            foreach (var name in playerNames)
            {
                _players.Add(new CompileItPlayer(name));
            }
        }

        private void UpdatePlayerIndex()
        {
            if(_currentPlayerIndex < _players.Count-1)
            {
                _currentPlayerIndex++;
            }
            else
            {
                _currentPlayerIndex = 0;
            }
        }
        
        public ITurnStatus RollDice()
        {
            CurrentPlayer.TakeRoll();
            return CurrentPlayer;
        }

        public string PassTurn()
        {
            if (!HasWinner)
            {
                CurrentPlayer.PassTurn();
                UpdatePlayerIndex();
            }
            return CurrentPlayerName;
        }
        #endregion
    }
}
