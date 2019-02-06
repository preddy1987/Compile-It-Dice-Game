using System;
using System.Collections.Generic;
using System.Text;
using CompileIt;

namespace CompileItCLI
{
    public class CompileItCLI
    {
        private ICompileItGame _game = null;

        public CompileItCLI(ICompileItGame game)
        {
            _game = game;

            // Display Splash Screen
        }

        public void MainMenu()
        {
            bool gameOver = false;
            while (!gameOver)
            {
                Console.WriteLine("1) Player Management");
                Console.WriteLine("2) Leader Board");
                Console.WriteLine("3) Start Game");
                Console.WriteLine("4) Quit");
                // Player Management
                // Leader Board
                // Start Game (Turn Menu)
                // Change Font
            }
        }

        public void PlayGame()
        {
            List<string> players = new List<string>()
            {
                "Chris",
                "Adam",
                "William"
            };

            // Setup player colors

            _game.Start(players);

            TurnMenu();
        }

        private void FontMenu()
        {

        }

        private void PlayerMenu()
        {

        }

        private void DisplayLeaderBoard()
        {
            
        }

        private void TurnMenu()
        {
            bool quit = false;
            while (!quit)
            {
                try
                {
                    Console.Clear();

                    if (_game.HasWinner)
                    {
                        Console.Clear();
                        Console.WriteLine("The winner is " + _game.CurrentPlayerName);
                        Console.ReadKey();
                        quit = true;
                    }
                    else
                    {
                        DisplayPlayerStatus();
                        Console.WriteLine();
                        Console.WriteLine("1) Roll");
                        Console.WriteLine("2) End Turn");
                        Console.WriteLine("3) Suicide");
                        // Score Board
                        
                        Console.WriteLine("Enter Selection....");

                        var selection = Console.ReadKey().KeyChar;
                        if (selection == '1')
                        {
                            RollDice();
                        }
                        else if (selection == '2')
                        {
                            _game.PassTurn();
                        }
                        else if (selection == '3')
                        {
                            quit = true;
                        }
                    }
                }
                catch(Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    Console.ReadKey();
                }
            }
        }

        private void RollDice()
        {
            ITurnStatus status = _game.RollDice();

            if (status.TurnErrors >= 3)
            {
                Console.Clear();
                Console.WriteLine("You busted!\n\nPress any key to continue...");
                Console.ReadKey();
                _game.PassTurn();
            }
        }

        private void DisplayPlayerStatus()
        {
            // Add colors for different players
            SetColor();

            // Undergo Beautification
            var status = _game.CurrentPlayerStatus;
            Console.WriteLine($"Player: {_game.CurrentPlayerName}");
            Console.WriteLine($"Round: {status.RoundCount} {(_game.IsLastRound ? " Last Turn" : "")}");
            Console.WriteLine($"Total Successes: {status.TotalSuccesses}");
            Console.WriteLine($"Turn Errors: {status.TurnErrors}");
            Console.WriteLine($"Turn Successes: {status.TurnSuccesses}");
            Console.WriteLine($"Turn Warnings: {status.TurnWarnings}");
            Console.WriteLine($"Odds: {status.Odds.ToString("N2")}");
            // Add information about dice in cup

            ResetColor();
        }

        private void SetColor()
        {
            //_game.CurrentPlayerName
        }

        private void ResetColor()
        {

        }
    }
}
