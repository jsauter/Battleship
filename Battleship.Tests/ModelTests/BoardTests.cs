using System.CodeDom;
using System.Linq;
using Battleship.Game.Exceptions;
using Battleship.Game.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Battleship.Tests.ModelTests
{
    [TestClass]
    public class BoardTests
    {       
        [TestMethod]
        [ExpectedException(typeof(BadShotException))]
        public void CannotFireShotOffBoard()
        {
            var board = new Board(string.Empty, 8, 8);
            
            board.FireShot(new Coordinate(9, 9));    
        }

        [TestMethod]
        public void CanPlaceOneShip()
        {
            var board = new Board(string.Empty, 8, 8);

            var ship = new Cruiser(new Coordinate(1, 1), new Coordinate(1, 3));

            board.PlaceShip(ship);

            Assert.AreEqual(1, board.Ships.Count);
        }

        [TestMethod]
        [ExpectedException(typeof(ShipCoordinatesInvalidException))]
        public void CannotPlaceShipCompletelyOffBoard()
        {
            var board = new Board(string.Empty, 8, 8);

            var ship = new Cruiser(new Coordinate(9, 9), new Coordinate(9, 11));

            board.PlaceShip(ship);
        }

        [TestMethod]
        [ExpectedException(typeof(ShipCoordinatesInvalidException))]
        public void CannotPlaceShipPartiallyOffBoardXAxis()
        {
            var board = new Board(string.Empty, 8, 8);

            var ship = new Cruiser(new Coordinate(7, 1), new Coordinate(9, 1));

            board.PlaceShip(ship);
        }

        [TestMethod]
        [ExpectedException(typeof(ShipCoordinatesInvalidException))]
        public void CannotPlaceShipPartiallyOffBoardYAxis()
        {
            var board = new Board(string.Empty, 8, 8);

            var ship = new Cruiser(new Coordinate(1, 7), new Coordinate(1, 9));

            board.PlaceShip(ship);
        }

        [TestMethod]
        [ExpectedException(typeof(ShipCoordinatesInvalidException))]
        public void CannotPlaceShipPartiallyOffBoardYAxisNegative()
        {
            var board = new Board(string.Empty, 8, 8);

            var ship = new Cruiser(new Coordinate(1, -1), new Coordinate(1, -3));

            board.PlaceShip(ship);
        }

        [TestMethod]
        [ExpectedException(typeof(ShipCoordinatesInvalidException))]
        public void CannotPlaceShipPartiallyOffBoardXAxisNegative()
        {
            var board = new Board(string.Empty, 8, 8);

            var ship = new Cruiser(new Coordinate(-3, 3), new Coordinate(-1, 3));

            board.PlaceShip(ship);
        }

        [TestMethod]
        [ExpectedException(typeof(BadShotException))]
        public void FiringTwoShotsAtSameCoordinateThrowsBadShotException()
        {
            var board = new Board(string.Empty, 8, 8);

            var ship = new Cruiser(new Coordinate(1, 1), new Coordinate(1, 3));

            board.PlaceShip(ship);

            board.FireShot(new Coordinate(2, 2));
            board.FireShot(new Coordinate(2, 2));
        }

        [TestMethod]
        public void GetBoardStateReturnsExpectedData()
        {
            var board = new Board(string.Empty, 8, 8);

            var ship = new Cruiser(new Coordinate(1, 1), new Coordinate(1, 3));

            board.PlaceShip(ship);

            board.FireShot(new Coordinate(1, 1));
            board.FireShot(new Coordinate(2, 1));
            board.FireShot(new Coordinate(3, 1));

            var boardState = board.GetBoardState();

            Assert.AreEqual(boardState.Count, 3);
            Assert.AreEqual(boardState.Count(x => x.Value == ShotResult.Hit), 1);
            Assert.AreEqual(boardState.Count(x => x.Value == ShotResult.Miss), 2);
        }
    }
}
