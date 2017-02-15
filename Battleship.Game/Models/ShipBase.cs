using System;
using System.Drawing;
using Battleship.Game.Exceptions;

namespace Battleship.Game.Models
{
    /// <summary>
    /// Ship base class.  
    /// You can use this as a base type if you want to add more ships to the game by just extending it and setting the length.  Ship lengths never change.
    /// </summary>
    public abstract class ShipBase : IShip
    {
        public Coordinate Start { get; protected set; }

        public Coordinate End { get; protected set; } 

        public int Length { get; protected set; }

        public string Name { get; protected set; }

        private int _hitCount;

        protected ShipBase(Coordinate start, Coordinate end, int length)
        {
            Start = start;
            End = end;
            Length = length;

            _hitCount = 0;

            ValidateShip();
        }

        /// <summary>
        /// Validation handles length and if the ship is horizontal or vertical as well as the right length for the placement parameters we have input
        /// Ships should someday check if they are being palced on top of other ships
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

        /// <summary>
        /// Checks if a shot coordinate hits the ship
        /// </summary>
        /// <param name="shotCoordinate">The coordinate of where the shot was fired</param>
        /// <returns>Boolean representing if it was a successful hit or not</returns>
        public bool IsHit(Coordinate shotCoordinate)
        {
            if (((Start.X <= shotCoordinate.X && shotCoordinate.X <= End.X) ||
                 (Start.X >= shotCoordinate.X && End.X <= shotCoordinate.X)) &&
                ((Start.Y <= shotCoordinate.Y && shotCoordinate.Y <= End.Y) ||
                 (Start.Y >= shotCoordinate.Y && End.Y <= shotCoordinate.Y)))
            {
                _hitCount++;

                if (_hitCount == Length)
                {
                    NotifyShipSunk();
                }

                return true;
            }            

            return false;
        }

        public event EventHandler ShipSunk;

        void NotifyShipSunk()
        {
            OnShipSunk(new ShipSunkEventArgs(this));
        }

        protected virtual void OnShipSunk(ShipSunkEventArgs shipSunkEventArgs)
        {
            ShipSunk?.Invoke(this, shipSunkEventArgs);
        }
    }
}