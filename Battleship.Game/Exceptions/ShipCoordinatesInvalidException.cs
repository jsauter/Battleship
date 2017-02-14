using System;

namespace Battleship.Game.Exceptions
{
    public class ShipCoordinatesInvalidException : Exception
    {
        public ShipCoordinatesInvalidException(string message) : base(message)
        {
        }
    }
}