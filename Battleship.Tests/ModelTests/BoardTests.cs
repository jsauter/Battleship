using Battleship.Game.Exceptions;
using Battleship.Game.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Battleship.Tests.ModelTests
{
    [TestClass]
    public class BoardTests
    {
        [TestMethod]
        public void CanPlaceOneShip()
        {
            var board = new Board(8, 8);

            var ship = new Cruiser(new Coordinate(1, 1), new Coordinate(1, 3));

            board.PlaceShip(ship);

            Assert.AreEqual(1, board.Ships.Count);
        }

        [TestMethod]
        [ExpectedException(typeof(ShipCoordinatesInvalidException))]
        public void CannotPlaceShipCompletelyOffBoard()
        {
            var board = new Board(8, 8);

            var ship = new Cruiser(new Coordinate(9, 9), new Coordinate(9, 11));

            board.PlaceShip(ship);
        }

        [TestMethod]
        [ExpectedException(typeof(ShipCoordinatesInvalidException))]
        public void CannotPlaceShipPartiallyOffBoardXAxis()
        {
            var board = new Board(8, 8);

            var ship = new Cruiser(new Coordinate(7, 1), new Coordinate(9, 1));

            board.PlaceShip(ship);
        }

        [TestMethod]
        [ExpectedException(typeof(ShipCoordinatesInvalidException))]
        public void CannotPlaceShipPartiallyOffBoardYAxis()
        {
            var board = new Board(8, 8);

            var ship = new Cruiser(new Coordinate(1, 7), new Coordinate(1, 9));

            board.PlaceShip(ship);
        }

        [TestMethod]
        [ExpectedException(typeof(ShipCoordinatesInvalidException))]
        public void CannotPlaceShipPartiallyOffBoardYAxisNegative()
        {
            var board = new Board(8, 8);

            var ship = new Cruiser(new Coordinate(1, -1), new Coordinate(1, -3));

            board.PlaceShip(ship);
        }

        [TestMethod]
        [ExpectedException(typeof(ShipCoordinatesInvalidException))]
        public void CannotPlaceShipPartiallyOffBoardXAxisNegative()
        {
            var board = new Board(8, 8);

            var ship = new Cruiser(new Coordinate(-3, 3), new Coordinate(-1, 3));

            board.PlaceShip(ship);
        }
    }
}
