using Battleship.Exceptions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Battleship.Tests.ConsoleTests
{
    [TestClass]
    public class CoordinateTranslatorTests
    {
        [TestMethod]
        public void TestValidInput()
        {
            var coordinateTranslator = new CoordinateTranslator();

            var coordinate = coordinateTranslator.TranslateCoordinate("A1");

            Assert.AreEqual(coordinate.X, 1);
            Assert.AreEqual(coordinate.Y, 1);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidInputException))]
        public void EnterBadFirstCharacterThrowsException()
        {
            var coordinateTranslator = new CoordinateTranslator();

            var coordinate = coordinateTranslator.TranslateCoordinate("11");            
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidInputException))]
        public void EnterBadSecondCharacterThrowsException()
        {
            var coordinateTranslator = new CoordinateTranslator();

            var coordinate = coordinateTranslator.TranslateCoordinate("AA");
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidInputException))]
        public void NullInputThrowException()
        {
            var coordinateTranslator = new CoordinateTranslator();

            var coordinate = coordinateTranslator.TranslateCoordinate(string.Empty);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidInputException))]
        public void TooBigInputThrowsException()
        {
            var coordinateTranslator = new CoordinateTranslator();

            var coordinate = coordinateTranslator.TranslateCoordinate("ABABAB");
        }
    }
}
