using System;
using System.Collections.Generic;

namespace Battleship.Game.Models
{
    /// <summary>
    /// Interface representing a player's board
    /// </summary>
    public interface IBoard
    {
        void PlaceShip(ShipBase ship);

        void FireShot(Coordinate shotCoordinate);

        Dictionary<Coordinate, ShotResult> GetBoardState();

        event EventHandler GameOver;
    }
}