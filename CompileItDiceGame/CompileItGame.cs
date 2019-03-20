using CompileItDiceGame.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Xml;
using System.Xml.Serialization;

namespace CompileIt
{
    public class CompileItGame : ICompileItGame
    {
        #region Member Variables

        private List<CompileItPlayer> _players = new List<CompileItPlayer>();
        private Random _dieRoller = new Random();

        private int _currentPlayerIndex = 0;
        private int _startPlayerIndex = 0;

        #endregion


        #region Properties

        public string CurrentPlayerName
        {
            get
            {
                return CurrentPlayer == null ? null : CurrentPlayer.Name;
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
                return _players.Count == 0 ? null : _players[_currentPlayerIndex];
            }
        }

        public double Odds
        {
            get
            {
                return CurrentPlayer == null ? 0.0 : CurrentPlayer.Odds;
            }
        }

        public ITurnStatus CurrentPlayerStatus
        {
            get
            {
                return CurrentPlayer == null ? null : ObjectCopier.Clone(CurrentPlayer);
            }
        }

        public bool IsTurnOver
        {
            get
            {
                return CurrentPlayer == null ? false : CurrentPlayer.IsTurnOver;
            }
        }

        public List<IPlayerStatus> PlayersStatus
        {
            get
            {
                List<IPlayerStatus> result = new List<IPlayerStatus>();

                foreach (var player in _players)
                {
                    result.Add(ObjectCopier.Clone(player));
                }

                return result;
            }
        }

        public List<IPlayerName> Players
        {
            get
            {
                List<IPlayerName> result = new List<IPlayerName>();

                foreach (var player in _players)
                {
                    result.Add(ObjectCopier.Clone(player));
                }

                return result;
            }
        }

        #endregion

        #region Constructors

        public CompileItGame()
        {

        }

        #endregion

        #region Methods

        public void Start()
        {
            if(_players.Count == 0)
            {
                throw new NoPlayersException();
            }
            Random rnd = new Random();
            _startPlayerIndex = rnd.Next(0, _players.Count);
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
            CurrentPlayer.TakeRoll(_dieRoller);
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

        public void SaveWinner(string playerName)
        {
            PlayerScore pastPlayers = new PlayerScore();
      
            string currentDir = Environment.CurrentDirectory + @"\..\..\..\..";

            string fileName = "LeaderBoard.xml";

            string fullPath = Path.Combine(currentDir, fileName);

            List<PlayerScore> playerScores = new List<PlayerScore>();

            XmlSerializer xmlSerializer = new XmlSerializer(playerScores.GetType());

            // If game win file exists load here
            if (File.Exists(fullPath))
            {
                // Reads the xml and adds the objects to the pastPlayers list
                using (StreamReader strReader = new StreamReader(fullPath))
                {
                    playerScores = (List<PlayerScore>) xmlSerializer.Deserialize(strReader);
                }
            }

            bool playerExists = false;
            foreach(var player in playerScores)
            {
                if(player.PlayerName == playerName)
                {
                    player.NumOfWins++;
                    playerExists = true;
                }
            }

            // If they are in the leader board file, increment wins
            if(!playerExists)
            {
                PlayerScore currentWinner = new PlayerScore();

                currentWinner.PlayerName = playerName;

                currentWinner.NumOfWins = 1;

                playerScores.Add(currentWinner);
            }

            using (StringWriter strWriter = new StringWriter())
            {
                using (XmlWriter xmlWriter = XmlWriter.Create(strWriter))
                {                    
                        xmlSerializer.Serialize(xmlWriter, playerScores);
                        string outXml = strWriter.ToString();

                        File.WriteAllText(fullPath, outXml);
                }
            }
        }

        public void AddPlayer(string playerName)
        {
            if(playerName == null || playerName == "")
            {
                throw new ArgumentException("Empty player names are not acceptable.");
            }
            else if (_players.Exists(m => m.Name == playerName))
            {
                throw new PlayerAlreadyExistsException();
            }
            _players.Add(new CompileItPlayer(playerName));
        }

        public void RemovePlayer(string playerName)
        {
            int index = _players.FindIndex(m => m.Name == playerName);
            if(index != -1)
            {
                _players.RemoveAt(index);
            }
            else
            {
                throw new PlayerNotFoundException();
            }
        }

        public void RemoveAllPlayers()
        {
            _players.Clear();
        }

        #endregion
    }
}
