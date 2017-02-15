using Battleship.Game.Models;

namespace Battleship.Game
{
    public interface IGameState
    {
        void AddBoard(string playerName);
        void AddShip(string playerName, Coordinate start, Coordinate end);
        void FireShot(string opposingPlayerName, Coordinate shotCoordinate);
    }
}