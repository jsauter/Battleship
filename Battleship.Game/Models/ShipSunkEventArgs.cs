using System;
using System.Security.Policy;

namespace Battleship.Game.Models
{
    public class ShipSunkEventArgs : EventArgs
    {
        public ShipBase Ship { get; protected set; }

        public ShipSunkEventArgs(ShipBase ship)
        {
            Ship = ship;
        }
    }
}