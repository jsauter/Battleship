using System;

namespace Battleship.Game.Exceptions
{
    public class BadShotException : Exception
    {
        public BadShotException(string message) : base(message)
        {
        }
    }
}