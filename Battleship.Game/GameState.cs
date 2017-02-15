using System.Collections.Generic;
using System.Linq;
using Battleship.Game.Models;

namespace Battleship.Game
{
    public class GameState : IGameState
    {
        private List<Board> _boards;
        private int _currentPlayerNumber;

        public GameState()
        {
            _boards = new List<Board>();
            _currentPlayerNumber = 1;
        }

        public void AddBoard(string playerName)
        {
            _boards.Add(new Board(playerName, 8, 8));
        }

        public void AddShip(string playerName, Coordinate start, Coordinate end)
        {
            var releventBoard = _boards.FirstOrDefault(x => x.PlayerName == playerName);

            if (releventBoard != null)
            {
                // assumption: we are only supporting cruisers right now
                // in the future you could use a ship factory here
                releventBoard.Ships.Add(new Cruiser(start, end));
            }            
        }

        public void FireShot(string opposingPlayerName, Coordinate shotCoordinate)
        {
        }

        public string GetCurrentPlayer()
        {
            var board = _boards[_currentPlayerNumber - 1];            

            return board.PlayerName;
        }

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