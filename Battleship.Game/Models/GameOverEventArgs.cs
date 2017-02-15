using System;

namespace Battleship.Game.Models
{
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