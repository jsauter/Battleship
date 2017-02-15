using System;

namespace Battleship.Exceptions
{
    /// <summary>
    /// A class to notify the consumer that whatever was entered by the user was bad input.
    /// </summary>
    public class InvalidInputException : Exception
    {
        public InvalidInputException(string message) : base(message)
        {
        }
    }
}