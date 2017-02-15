using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using Battleship.Game.Models;

namespace Battleship.Game
{
    public class GameState : IGameState
    {
        private List<Board> _boards;

        public GameState()
        {
            _boards = new List<Board>();
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
    }
}