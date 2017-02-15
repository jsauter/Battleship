using System;

namespace Battleship.Game.Exceptions
{
    /// <summary>
    /// Exception that notifies the consumer that a ships placement or size is wrong
    /// </summary>
    public class ShipCoordinatesInvalidException : Exception
    {
        public ShipCoordinatesInvalidException(string message) : base(message)
        {
        }
    }
}