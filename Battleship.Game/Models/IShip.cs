using System;

namespace Battleship.Game.Models
{
    public interface IShip
    {
        bool IsHit(Coordinate shotCoordinate);

        event EventHandler ShipSunk;
    }
}