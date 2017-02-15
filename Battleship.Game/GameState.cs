using System.Collections.Generic;
using System.Linq;
using Battleship.Game.Models;

namespace Battleship.Game
{
    public class GameState : IGameState
    {
        private List<Board> _boards;
        private int _currentPlayerNumber;

        public bool IsGameOver { get; protected set; }

        public GameState()
        {
            _boards = new List<Board>();
            _currentPlayerNumber = 1;
        }

        public IEnumerable<string> GetPlayerNames()
        {
            return _boards.Select(x => x.PlayerName);
        }

        public Board GetBoard(string playerName)
        {
            return _boards.FirstOrDefault(x => x.PlayerName == playerName);
        }

        /// <summary>
        /// This method adds a new board and player to the game state
        /// </summary>
        /// <param name="playerName">The Name of the player</param>
        public void AddBoard(string playerName)
        {
            var newBoard = new Board(playerName, 8, 8);
            newBoard.GameOver += NewBoard_GameOver;
            _boards.Add(newBoard);
        }

        private void NewBoard_GameOver(object sender, System.EventArgs e)
        {
            IsGameOver = true;
        }

        /// <summary>
        /// Adds a ship to a players board
        /// </summary>
        /// <param name="playerName">Player who's board the ship is being added to</param>
        /// <param name="start">Start coordinate of the ship</param>
        /// <param name="end">End coordinate of the ship</param>
        public void AddShip(string playerName, Coordinate start, Coordinate end)
        {
            var releventBoard = _boards.FirstOrDefault(x => x.PlayerName == playerName);

            if (releventBoard != null)
            {
                // assumption: we are only supporting cruisers right now
                // in the future you could use a ship factory here
                releventBoard.PlaceShip(new Cruiser(start, end));
            }            
        }

        /// <summary>
        /// Fires a shot at a player's board
        /// </summary>
        /// <param name="opposingPlayerName">The player who you are firing the shot against</param>
        /// <param name="shotCoordinate">The coordinate of the shot</param>
        public void FireShot(string opposingPlayerName, Coordinate shotCoordinate)
        {
            var board = _boards.FirstOrDefault(x => x.PlayerName == opposingPlayerName);

            board.FireShot(shotCoordinate);
        }

        /// <summary>
        /// Gets the string name of the player whos turn it is
        /// </summary>
        /// <returns>The name of the player</returns>
        public string GetCurrentPlayer()
        {
            return GetPlayer();
        }
      
        /// <summary>
        /// Gets the opponent for the current player who's turn it is.
        /// </summary>
        /// <returns>The current opponent</returns>
        public string GetCurrentOpponent()
        {
            return _boards.First(x => x.PlayerName != GetPlayer()).PlayerName;
        }

        private string GetPlayer()
        {
            var board = _boards[_currentPlayerNumber - 1];
            return board.PlayerName;
        }

        /// <summary>
        /// Rolls the game to the next player after someone takes a turn
        /// </summary>
        public void MoveToNextPlayer()
        {
            // increment player number unless it is second player, then send it back to 1
            _currentPlayerNumber++;

            // we don't support more than 2 players
            if (_currentPlayerNumber == 3)
            {
                _currentPlayerNumber = 1;
            }
        }
    }
}