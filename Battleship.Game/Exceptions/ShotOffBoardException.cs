using System;

namespace Battleship.Game.Exceptions
{
    public class ShotOffBoardException : Exception
    {
        public ShotOffBoardException(string message) : base(message)
        {
        }
    }
}