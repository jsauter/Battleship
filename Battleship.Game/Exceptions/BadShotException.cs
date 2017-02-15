using System;

namespace Battleship.Game.Exceptions
{
    /// <summary>
    /// Exception that notifies consumers that a placed shot did not meet the specific criteria for the game (i.e., on the board, not fired in the same place twice, etc.)
    /// </summary>
    public class BadShotException : Exception
    {
        public BadShotException(string message) : base(message)
        {
        }
    }
}