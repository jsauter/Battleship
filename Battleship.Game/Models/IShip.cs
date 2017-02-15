﻿using System;

namespace Battleship.Game.Models
{
    /// <summary>
    /// Interface representing a ship placed on a player's board
    /// </summary>
    public interface IShip
    {
        bool IsHit(Coordinate shotCoordinate);

        event EventHandler ShipSunk;
    }
}