using System.Collections.Generic;
using Battleship.Game.Models;

namespace Battleship.Game
{
    public interface IGameState
    {
        IEnumerable<string> GetPlayerNames();
        Board GetBoard(string playerName);
        void AddBoard(string playerName);
        void AddShip(string playerName, Coordinate start, Coordinate end);
        void FireShot(string opposingPlayerName, Coordinate shotCoordinate);
        string GetCurrentPlayer();
        string GetCurrentOpponent();
        void MoveToNextPlayer();
        bool IsGameOver { get; }
    }
}