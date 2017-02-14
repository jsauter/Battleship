using System.Collections.Generic;
using Battleship.Game.Exceptions;

namespace Battleship.Game.Models
{
    /// <summary>
    /// The Board class represents a player's board in the game.  
    /// A board inherits from IBoard so we can have access to the methods defined there
    /// It has an X and Y length that represents it's size.  
    /// We are only supporting once size of board in the game, in this case 8x8.
    /// A board contains a list of ships.  In the future, the list will allow us to add more than one ship to the game.
    /// </summary>
    public class Board : IBoard
    {
        public string PlayerName { get; set; }
        public int XLength { get; set; }
        public int YLength { get; set; }
        public List<Coordinate> Shots { get; set; }
        public List<ShipBase> Ships { get; set; }

        public Board(string playerName, int xLength, int yLength)
        {
            PlayerName = playerName;
            XLength = xLength;
            YLength = yLength;

            Ships = new List<ShipBase>();
            Shots = new List<Coordinate>();
        }

        public void PlaceShip(ShipBase ship)
        {
            // check if ship is legally on the board
            if (ship.Start.X > XLength || ship.End.X > XLength || ship.Start.X < 1 || ship.End.X < 1
                || ship.Start.Y > YLength || ship.End.Y > XLength || ship.Start.Y < 1 || ship.End.Y < 1
                )
            {
                throw new ShipCoordinatesInvalidException("Ship placed off the board.");
            }

            // TODO: when a requirement comes up to have more than one ship, we will need to check for intersections
            
            Ships.Add(ship);
        }

        public void FireShot(Coordinate coordinate)
        {
        }
    }
}