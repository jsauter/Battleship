using System;
using System.Security.Policy;

namespace Battleship.Game.Models
{
    /// <summary>
    /// Event args that notify a consumer that a ship has been sunk
    /// </summary>
    public class ShipSunkEventArgs : EventArgs
    {
        public ShipBase Ship { get; protected set; }

        public ShipSunkEventArgs(ShipBase ship)
        {
            Ship = ship;
        }
    }
}