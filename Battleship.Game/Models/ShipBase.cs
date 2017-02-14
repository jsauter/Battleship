using System;
using System.Drawing;
using System.Security.AccessControl;
using Battleship.Game.Exceptions;

namespace Battleship.Game.Models
{
    /// <summary>
    /// Ship base class.  
    /// You can use this as a base type if you want to add more ships to the game by just extending it and setting the length.  Ship lengths never change.
    /// </summary>
    public abstract class ShipBase : IShip
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

        public bool IsHit(Coordinate shotCoordinate)
        {
            var rectangle = new Rectangle(Start.X, Start.Y, Start.Y - End.Y != 0 ? 1 : Length, Start.X - End.X != 0 ? 1 : Length);

            return rectangle.Contains(shotCoordinate.X, shotCoordinate.Y);

            //return ((Start.X <= shotCoordinate.X) && (shotCoordinate.X <= End.X))
            //        || (End.X <= shotCoordinate.X) && (shotCoordinate.X <= Start.X) &&
            //        (Start.Y <= shotCoordinate.Y) && (shotCoordinate.Y <= End.Y)
            //        || ((End.Y <= shotCoordinate.Y) && (shotCoordinate.X <= Start.Y));
        }
    }
}