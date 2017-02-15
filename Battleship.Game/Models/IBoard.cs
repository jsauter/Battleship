using System;
using System.Collections.Generic;

namespace Battleship.Game.Models
{
    public interface IBoard
    {
        void PlaceShip(ShipBase ship);

        void FireShot(Coordinate shotCoordinate);

        Dictionary<Coordinate, ShotResult> GetBoardState();

        event EventHandler GameOver;
    }
}