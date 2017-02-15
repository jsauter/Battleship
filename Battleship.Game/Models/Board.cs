using System;
using System.Collections.Generic;
using System.Linq;
using Battleship.Game.Exceptions;

namespace Battleship.Game.Models
{
    /// <summary>
    /// The Board class represents a player's board in the game.  
    /// A board inherits from IBoard so we can have access to the methods defined there
    /// It has an X and Y length that represents it's size.  
    /// A board contains a list of ships.  In the future, the list will allow us to add more than one ship to the game.
    /// </summary>
    public class Board : IBoard
    {
        public string PlayerName { get; protected set; }

        public int XLength { get; protected set; }

        public int YLength { get; protected set; }

        private readonly List<Coordinate> _shots;

        public IReadOnlyCollection<Coordinate> Shots => _shots.AsReadOnly();

        private readonly List<ShipBase> _ships;

        public IReadOnlyCollection<ShipBase> Ships => _ships.AsReadOnly();

        private readonly Dictionary<Coordinate, ShotResult> _boardState;

        /// <summary>
        /// Creates a new board for the player. The board keeps track of what shots were placed against it and if it was a hit or a miss.
        /// </summary>
        /// <param name="playerName">Name of the player</param>
        /// <param name="xLength">Horizontal size of the board</param>
        /// <param name="yLength">Vertical size of the board</param>
        public Board(string playerName, int xLength, int yLength)
        {
            PlayerName = playerName;
            XLength = xLength;
            YLength = yLength;
            
            _ships = new List<ShipBase>();
            _shots = new List<Coordinate>();
            _boardState = new Dictionary<Coordinate, ShotResult>();
        }

        /// <summary>
        /// Places ship on the board
        /// </summary>
        /// <param name="ship">The ship we are placing</param>
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

            ship.ShipSunk += Ship_ShipSunk;

            _ships.Add(ship);
        }

        private void Ship_ShipSunk(object sender,EventArgs e)
        {
            var args = (ShipSunkEventArgs) e;

            NotifyGameOver(args.Ship);
        }

        /// <summary>
        /// Fire a shot on the board
        /// </summary>
        /// <param name="shotCoordinate">Coordinates of the shot</param>
        public void FireShot(Coordinate shotCoordinate)
        {
            if (shotCoordinate.X < 1 || shotCoordinate.X > XLength || shotCoordinate.Y < 1 || shotCoordinate.Y > YLength)
            {
                throw new BadShotException("Shot fired off board.");
            }

            if (_boardState.Keys.Count(x => x.X == shotCoordinate.X && x.Y == shotCoordinate.Y) > 0)
            {
                throw new BadShotException("A shot has already been fired at that coordinate.");
            }

            foreach (var ship in Ships)
            {
                _boardState.Add(shotCoordinate, ship.IsHit(shotCoordinate) ? ShotResult.Hit : ShotResult.Miss);
            }
        }

        public Dictionary<Coordinate, ShotResult> GetBoardState()
        {
            return _boardState;
        }

        public event EventHandler GameOver;

        void NotifyGameOver(ShipBase ship)
        {
            OnNotifyGameOver(new GameOverEventArgs(PlayerName, ship));
        }

        protected virtual void OnNotifyGameOver(GameOverEventArgs gameOverEventArgs)
        {
            GameOver?.Invoke(this, gameOverEventArgs);
        }
    }
}