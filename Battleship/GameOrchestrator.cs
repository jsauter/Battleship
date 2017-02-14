using System;
using System.Collections.Generic;
using Battleship.Game.Models;

namespace Battleship
{
    /// <summary>
    /// The GameOrchestrator manages the console output as well as the user input for the game run.  
    /// </summary>
    public class GameOrchestrator : IGameOrchestrator
    {
        private readonly ICoordinateTranslator _coordinateTranslator;

        private List<Board> _gameBoards;

        public GameOrchestrator(ICoordinateTranslator coordinateTranslator)
        {
            _coordinateTranslator = coordinateTranslator;
            _gameBoards = new List<Board>();
        }

        public void StartGame()
        {
            Console.WriteLine("Game Starting...");

            // here we are taking in the user input for ship placement and translating them to board coordinates 
            for (int i = 1; i < 3; i++)
            {
                var newBoard = new Board($"Player{0}", 8, 8);                

                while (true)
                {
                    
                    Console.WriteLine($"Please enter the ship location for Player {i}. Format A3 A5");
                    var userInputString = Console.ReadLine().Split(' ');

                    try
                    {
                        var start = _coordinateTranslator.TranslateCoordinate(userInputString[0]);
                        var end = _coordinateTranslator.TranslateCoordinate(userInputString[1]);

                        newBoard.Ships.Add(new Cruiser(start, end));

                        break;
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }


                }

                _gameBoards.Add(newBoard);
            }

            // now we take in user input over and over again until someone wins

            while (true)
            {
                
            }

            Console.WriteLine("Game over...");
            Console.ReadLine();
        }
    }
}