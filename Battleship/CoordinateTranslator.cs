using Battleship.Exceptions;
using Battleship.Game.Models;

namespace Battleship
{
    public class CoordinateTranslator : ICoordinateTranslator
    {
        public Coordinate TranslateCoordinate(string userInput)
        {
            var splitInput = userInput.ToCharArray();

            if (splitInput.Length != 2)
            {
                throw new InvalidInputException("Coordinate must be 2 characters.");
            }

            if (!char.IsLetter(splitInput[0]))
            {
                throw new InvalidInputException("First character of coordinate must be a letter A-H.");
            }

            if (!char.IsDigit(splitInput[1]))
            {
                throw new InvalidInputException("Second character of coordinate must be a number 1-8.");
            }

            return new Coordinate(char.ToUpper(splitInput[0]) - 64, (int)char.GetNumericValue(splitInput[1]));
        }
    }
}