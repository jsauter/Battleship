using System;
using Battleship.Game.Exceptions;

namespace Battleship.Game.Models
{
    /// <summary>
    /// Ship base class.  
    /// You can use this as a base type if you want to add more ships to the game by just extending it and setting the length.  Ship lengths never change.
    /// </summary>
    public abstract class ShipBase
    {
        public Coordinate Start { get; set; }
        public Coordinate End { get; set; } 
        public int Length { get; set; }

        protected ShipBase(Coordinate start, Coordinate end, int length)
        {
            Start = start;
            End = end;
            Length = length;

            ValidateShip();
        }

        /// <summary>
        /// Validation handles length and if the ship is horizontal or vertical
        /// </summary>
        private void ValidateShip()
        {
            if (!IsShipHorizontalOrVertical())
            {
                throw new ShipCoordinatesInvalidException("Ship not horizontal or vertical");
            }

            if (!IsShipEqualToClassLength())
            {
                throw new ShipCoordinatesInvalidException("Ship coordinates not valid for ship length.");
            }
        }

        private bool IsShipEqualToClassLength()
        {
            // we need to subtract from the length by 1 because the distance between two points is one less.  In the game of battleship a ship would overrun it's bounds 
            // if we used didn't take this into account
            return Math.Sqrt(Math.Pow((End.Y - Start.Y), 2) + Math.Pow((End.X - Start.X), 2)) == (Length - 1);
        }

        private bool IsShipHorizontalOrVertical()
        {
            bool isValid = false;

            try
            {
                //check slope to make sure horizontal or vertical
                if ((End.Y - Start.Y) / (End.X - Start.X) == 0)
                {
                    isValid = true;
                }
            }
            catch (DivideByZeroException)
            {
                //since we are calculating slope, we should eat this divide by zero exception as a vertical line's slope is undefined
                isValid = true;
            }

            
            return isValid;
        }
    }
}