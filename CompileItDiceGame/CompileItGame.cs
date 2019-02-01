using System;
using System.Collections.Generic;

namespace CompileIt
{
    public class CompileItGame : ICompileItGame
    {
        #region Member Variables
        private List<CompileItPlayer> _players = null;

        private int _currentPlayerIndex = 0;
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
                foreach(var player in _players)
                {
                    if(player.IsWinner)
                    {
                        hasWinner = true;
                    }
                }
                return hasWinner;
            }
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
            _currentPlayerIndex = 0;
            SetupPlayers(playerNames);
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
