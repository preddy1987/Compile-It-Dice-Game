using System;
using System.Collections.Generic;
using System.Text;
using CompileIt;

namespace CompileItCLI
{
    public class CompileItCLI
    {
        private ICompileItGame _game = null;

        private List<string> _players = new List<string>();
            
               
           

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
                // Player Management


                // Leader Board
                // Start Game (Turn Menu)
                // Change Font
            }
        }

        public void PlayGame()
        {
            

            // Setup player colors

            _game.Start(_players);

            TurnMenu();
        }

        private void FontMenu()
        {

        }

        private void PlayerMenu()
        {
            // loop for valid input
            bool validChoice = false;
            int playerChoice = 0;
            bool quit = false;

            while (!validChoice || quit)
            {
                DisplayPlayerMenu();
                playerChoice = PlayerMenuChoice();
                
                ProcessMenuChoice(playerChoice);
            }

            
                
            //display menu method
            // queury user for their choice
            // choices are add player, remove player, back to main menu


        }

        private void ProcessMenuChoice(int playerChoice)
        {
            if(playerChoice == 1)
            {
                string playerName = "";
                bool nameAdded = false;
                while (!nameAdded)
                {
                    nameAdded = true;
                    Console.WriteLine("Enter Name");
                    playerName = Console.ReadLine();
                    foreach (string name in _players)
                    {
                        if (name == playerName)
                        {
                            Console.WriteLine("Name is already taken, choose another.");
                            nameAdded = false;
                        }
                    }
                }
                //we have A UNIQUE NAME.
                _players.Add(playerName)
                    

            }
            else if(playerChoice == 2)
            {

            }
            else if(playerChoice == 3)
            {

            }


        }
        private int PlayerMenuChoice()
        {
            string userInput = Console.ReadLine();
            int playerChoice = 0;
            int result = 0;
            try
            {
                playerChoice = int.Parse(userInput);
                if(playerChoice >=1 || playerChoice <= 3)
                {
                    result = playerChoice;
                }


            }
            catch (ArgumentException ex)
            {
                Console.WriteLine("Please enter 1, 2, or 3.  Hit any key to continue.");
            }
            return result;
        }

        private void DisplayPlayerMenu()
        {
            Console.Clear();
            Console.WriteLine("1.) Add Player");
            Console.WriteLine("2.) Remove Player");
            Console.WriteLine("3.) Back To Main Menu");
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
                        // Log winner data to file
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
