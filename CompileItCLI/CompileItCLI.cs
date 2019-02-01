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
        }

        public void MainMenu()
        {
            bool gameOver = false;
            while (!gameOver)
            {
                // Get player names
                // Start new game
                // Quit   
                PlayGame();
                gameOver = true;
            }
        }

        public void PlayGame()
        {
            List<string> players = new List<string>()
            {
                "Chris",
                "Amy"
            };

            _game.Start(players);

            TurnMenu();
        }

        private void TurnMenu()
        {
            bool quit = false;
            while (!quit)
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
                    Console.WriteLine("3) Quit Game");
                    Console.WriteLine("Enter Selection....");

                    var selection = Console.ReadKey().KeyChar;
                    ITurnStatus status = null;
                    if (selection == '1')
                    {
                        status = _game.RollDice();
                        
                        if (status.TurnErrors >= 3)
                        {
                            Console.Clear();
                            Console.WriteLine("You busted!\n\nPress any key to continue...");
                            Console.ReadKey();
                            _game.PassTurn();
                        }
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
        }

        private void DisplayPlayerStatus()
        {
            var status = _game.CurrentPlayerStatus;
            Console.WriteLine($"Player: {_game.CurrentPlayerName}");
            Console.WriteLine($"Round: {status.RoundCount}");
            Console.WriteLine($"Total Successes: {status.TotalSuccesses}");
            Console.WriteLine($"Turn Errors: {status.TurnErrors}");
            Console.WriteLine($"Turn Successes: {status.TurnSuccesses}");
            Console.WriteLine($"Turn Warnings: {status.TurnWarnings}");
            Console.WriteLine($"Odds: {status.Odds.ToString("N2")}");
        }
    }
}
