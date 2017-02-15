using System;
using System.Collections.Generic;
using Battleship.Game.Exceptions;
using Battleship.Game.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Battleship.Tests.ModelTests
{
    [TestClass]
    public class ShipTests
    {
        [TestMethod]
        public void CreatingACruiserHasTheRightNameString()
        {
            var cruiser = new Cruiser(new Coordinate(1, 1), new Coordinate(1, 3));

            Assert.AreEqual(cruiser.Name, "Cruiser");
        }

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

        [TestMethod]
        [ExpectedException(typeof(ShipCoordinatesInvalidException))]
        public void DiagnolShipIsNotValid()
        {
            var cruiser = new Cruiser(new Coordinate(1, 1), new Coordinate(3, 3));
        }

        [TestMethod]
        public void IsNotHit()
        {
            var cruiser = new Cruiser(new Coordinate(1, 1), new Coordinate(1, 3));
            var shot = new Coordinate(2, 6);

            Assert.IsFalse(cruiser.IsHit(shot));
        }

        [TestMethod]
        public void IsHit()
        {
            var cruiser = new Cruiser(new Coordinate(1, 1), new Coordinate(1, 3));
            var shot1 = new Coordinate(1, 2);

            Assert.IsTrue(cruiser.IsHit(shot1));

            var shot2 = new Coordinate(1, 1);

            Assert.IsTrue(cruiser.IsHit(shot2));

            var shot3 = new Coordinate(1, 3);

            Assert.IsTrue(cruiser.IsHit(shot3));
        }

        /// <summary>
        /// These tests will check all border conditions as well as hits for a cruiser
        /// </summary>

        [TestMethod]
        public void ProximityIsHitAndMissHorzontal()
        {
            var cruiser = new Cruiser(new Coordinate(2, 2), new Coordinate(4, 2));

            var hit1 = new Coordinate(2, 2);
            var hit2 = new Coordinate(3, 2);
            var hit3 = new Coordinate(4, 2);

            Assert.IsTrue(cruiser.IsHit(hit1));
            Assert.IsTrue(cruiser.IsHit(hit2));
            Assert.IsTrue(cruiser.IsHit(hit3));
            
            // below misses
            var miss1 = new Coordinate(1, 1);
            var miss2 = new Coordinate(2, 1);
            var miss3 = new Coordinate(3, 1);
            var miss4 = new Coordinate(4, 1);
            var miss5 = new Coordinate(5, 1);

            // side to side misses
            var miss6 = new Coordinate(1, 2);
            var miss7 = new Coordinate(5, 2);

            // above misses
            var miss8 = new Coordinate(1, 3);
            var miss9 = new Coordinate(2, 3);
            var miss10 = new Coordinate(3, 3);
            var miss11 = new Coordinate(4, 3);
            var miss12 = new Coordinate(5, 3);

            Assert.IsFalse(cruiser.IsHit(miss1));
            Assert.IsFalse(cruiser.IsHit(miss2));
            Assert.IsFalse(cruiser.IsHit(miss3));
            Assert.IsFalse(cruiser.IsHit(miss4));
            Assert.IsFalse(cruiser.IsHit(miss5));
            Assert.IsFalse(cruiser.IsHit(miss6));
            Assert.IsFalse(cruiser.IsHit(miss7));
            Assert.IsFalse(cruiser.IsHit(miss8));
            Assert.IsFalse(cruiser.IsHit(miss9));
            Assert.IsFalse(cruiser.IsHit(miss10));
            Assert.IsFalse(cruiser.IsHit(miss11));
            Assert.IsFalse(cruiser.IsHit(miss12));
        }

        [TestMethod]
        public void ProximityIsHitAndMissVertical()
        {
            var cruiser = new Cruiser(new Coordinate(2, 2), new Coordinate(2, 4));

            var hit1 = new Coordinate(2, 2);
            var hit2 = new Coordinate(2, 3);
            var hit3 = new Coordinate(2, 4);

            Assert.IsTrue(cruiser.IsHit(hit1));
            Assert.IsTrue(cruiser.IsHit(hit2));
            Assert.IsTrue(cruiser.IsHit(hit3));

            // left misses
            var miss1 = new Coordinate(1, 1);
            var miss2 = new Coordinate(1, 2);
            var miss3 = new Coordinate(1, 3);
            var miss4 = new Coordinate(1, 4);
            var miss5 = new Coordinate(1, 5);

            // top and bottom misses
            var miss6 = new Coordinate(1, 1);
            var miss7 = new Coordinate(1, 5);

            // right misses
            var miss8 = new Coordinate(3, 1);
            var miss9 = new Coordinate(3, 2);
            var miss10 = new Coordinate(3, 3);
            var miss11 = new Coordinate(3, 4);
            var miss12 = new Coordinate(3, 5);

            Assert.IsFalse(cruiser.IsHit(miss1));
            Assert.IsFalse(cruiser.IsHit(miss2));
            Assert.IsFalse(cruiser.IsHit(miss3));
            Assert.IsFalse(cruiser.IsHit(miss4));
            Assert.IsFalse(cruiser.IsHit(miss5));
            Assert.IsFalse(cruiser.IsHit(miss6));
            Assert.IsFalse(cruiser.IsHit(miss7));
            Assert.IsFalse(cruiser.IsHit(miss8));
            Assert.IsFalse(cruiser.IsHit(miss9));
            Assert.IsFalse(cruiser.IsHit(miss10));
            Assert.IsFalse(cruiser.IsHit(miss11));
            Assert.IsFalse(cruiser.IsHit(miss12));
        }

        // Tests when the ship is 'forward' meaning the start is to the left of the end on horizontal
        [TestMethod]
        public void ForwardSinkingAShipRaisesEvent()
        {
            var receivedEvents = new List<string>();

            var ship = new Cruiser(new Coordinate(1,1), new Coordinate(3,1));

            ship.ShipSunk += delegate(object sender, EventArgs e)
            {
                receivedEvents.Add("Ship sunk!");
            };

            ship.IsHit(new Coordinate(1, 1));
            ship.IsHit(new Coordinate(2, 1));
            ship.IsHit(new Coordinate(3, 1));

            Assert.AreEqual(1, receivedEvents.Count);            
        }

        // Tests when the ship is 'backwards' meaning the start is to the right of the end on horizontal
        [TestMethod]
        public void BackwardShipSinkingRaisesEvent()
        {
            var receivedEvents = new List<string>();

            var ship = new Cruiser(new Coordinate(3, 1), new Coordinate(1, 1));

            ship.ShipSunk += delegate (object sender, EventArgs e)
            {
                receivedEvents.Add("Ship sunk!");
            };

            ship.IsHit(new Coordinate(1, 1));
            ship.IsHit(new Coordinate(2, 1));
            ship.IsHit(new Coordinate(3, 1));

            Assert.AreEqual(1, receivedEvents.Count);
        }

        // Tests when the ship is 'forward' meaning the start is to the left of the end on horizontal
        [TestMethod]
        public void RightsideUpSinkingAShipRaisesEvent()
        {
            var receivedEvents = new List<string>();

            var ship = new Cruiser(new Coordinate(1, 1), new Coordinate(1, 3));

            ship.ShipSunk += delegate (object sender, EventArgs e)
            {
                receivedEvents.Add("Ship sunk!");
            };

            ship.IsHit(new Coordinate(1, 1));
            ship.IsHit(new Coordinate(1, 2));
            ship.IsHit(new Coordinate(1, 3));

            Assert.AreEqual(1, receivedEvents.Count);
        }

        // Tests when the ship is 'backwards' meaning the start is to the right of the end on horizontal
        [TestMethod]
        public void UpsidedDownShipSinkingRaisesEvent()
        {
            var receivedEvents = new List<string>();

            var ship = new Cruiser(new Coordinate(1, 3), new Coordinate(1, 1));

            ship.ShipSunk += delegate (object sender, EventArgs e)
            {
                receivedEvents.Add("Ship sunk!");
            };

            ship.IsHit(new Coordinate(1, 1));
            ship.IsHit(new Coordinate(1, 2));
            ship.IsHit(new Coordinate(1, 3));

            Assert.AreEqual(1, receivedEvents.Count);
        }
    }
}
