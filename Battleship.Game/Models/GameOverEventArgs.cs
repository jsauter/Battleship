using System;

namespace Battleship.Game.Models
{
    /// <summary>
    /// Event args for when the game is over.  It will let the consumer of the event know the ship that was sunk and the winning player.
    /// </summary>
    public class GameOverEventArgs : EventArgs
    {
        public string WinningPlayer { get; protected set; }

        public ShipBase Ship { get; protected set; }

        public GameOverEventArgs(string winningPlayer, ShipBase ship)
        {
            WinningPlayer = winningPlayer;
            Ship = ship;
        }
    }
}