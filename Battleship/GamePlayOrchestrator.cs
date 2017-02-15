using System;
using Battleship.Game;

namespace Battleship
{
    /// <summary>
    /// The GamePlayOrchestrator manages the console output as well as the user input for the game run.  
    /// </summary>
    public class GamePlayOrchestrator : IGamePlayOrchestrator
    {
        private readonly ICoordinateTranslator _coordinateTranslator;

        private readonly IGameState _gameState;

        private readonly IBoardRenderer _boardRenderer;

        public GamePlayOrchestrator(ICoordinateTranslator coordinateTranslator, IGameState gameState, IBoardRenderer boardRenderer)
        {
            _coordinateTranslator = coordinateTranslator;
            _gameState = gameState;
            _boardRenderer = boardRenderer;
        }

        public void StartGame()
        {
            Console.WriteLine("Game Starting...");

            // here we are taking in the user input for ship placement and translating them to board coordinates 
            for (int i = 1; i < 3; i++)
            {
                var playerName = $"Player {i}";

                _gameState.AddBoard(playerName);

                while (true)
                {
                    Console.WriteLine($"Please enter the ship location for Player {i}. Format A3 A5");

                    var userInput = Console.ReadLine();

                    if (userInput != null)
                    {
                        var userInputString = userInput.Split(' ');

                        try
                        {
                            var start = _coordinateTranslator.TranslateCoordinate(userInputString[0]);
                            var end = _coordinateTranslator.TranslateCoordinate(userInputString[1]);

                            _gameState.AddShip(playerName, start, end);

                            break;
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine(ex.Message);
                        }
                    }
                }
            }

            // now we take in user input over and over again until someone wins
            while (true)
            {
                try
                {
                    var currentPlayer = _gameState.GetCurrentPlayer();
                    var currentOpponent = _gameState.GetCurrentOpponent();

                    Console.WriteLine($"{currentPlayer}: Provide a location to hit {currentOpponent} ship. Format B5");

                    var userInput = Console.ReadLine();

                    var shot = _coordinateTranslator.TranslateCoordinate(userInput);

                    _gameState.FireShot(currentOpponent, shot);

                    if (_gameState.IsGameOver)
                    {
                        // we found a winner, break the loop
                        break;
                    }

                    _gameState.MoveToNextPlayer();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }

            // print output
            Console.WriteLine($"Congratulations {_gameState.GetCurrentPlayer()} you sunk my battleship.");

            var players = _gameState.GetPlayerNames();

            foreach (var player in players)
            {
                Console.WriteLine($"{player} Board:");
                
                _boardRenderer.RenderBoard(_gameState.GetBoard(player));
            }
         
            Console.WriteLine("Game over...");
            Console.ReadLine();
        }
    }
}