using System;
using Battleship.Game.Exceptions;
using Battleship.Game.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Battleship.Tests.ModelTests
{
    [TestClass]
    public class CruiserTests
    {
        [TestMethod]
        public void CreateCruiserVertical()
        {
            var cruiser = new Cruiser(new Coordinate(1, 1), new Coordinate(1, 3));

            Assert.IsInstanceOfType(cruiser, typeof(ShipBase));
            Assert.AreEqual(3, cruiser.Length);
        }

        [TestMethod]
        public void CreateCruiserHorizontal()
        {
            var cruiser = new Cruiser(new Coordinate(1, 1), new Coordinate(3, 1));

            Assert.IsInstanceOfType(cruiser, typeof(ShipBase));
            Assert.AreEqual(3, cruiser.Length);
        }

        [TestMethod]
        [ExpectedException(typeof(ShipCoordinatesInvalidException))]
        public void ShipNotPlacedVerticallyOrHorizontallyThrowsException()
        {
            var cruiser = new Cruiser(new Coordinate(1,1), new Coordinate(3, 2));
        }

        [TestMethod]
        [ExpectedException(typeof(ShipCoordinatesInvalidException))]
        public void ShipXCoordinatesTooSmallForClassException()
        {
            var cruiser = new Cruiser(new Coordinate(1, 1), new Coordinate(2, 1));
        }

        [TestMethod]
        [ExpectedException(typeof(ShipCoordinatesInvalidException))]
        public void ShipXCoordinatesTooBigForClassException()
        {
            var cruiser = new Cruiser(new Coordinate(1, 1), new Coordinate(4, 1));
        }

        [TestMethod]
        [ExpectedException(typeof(ShipCoordinatesInvalidException))]
        public void ShipYCoordinatesTooSmallForClassException()
        {
            var cruiser = new Cruiser(new Coordinate(1, 1), new Coordinate(1, 2));
        }

        [TestMethod]
        [ExpectedException(typeof(ShipCoordinatesInvalidException))]
        public void ShipYCoordinatesTooBigForClassException()
        {
            var cruiser = new Cruiser(new Coordinate(1, 1), new Coordinate(1, 4));
        }
    }
}
