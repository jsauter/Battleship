using Battleship.Exceptions;
using Battleship.Game.Models;

namespace Battleship
{
    /// <summary>
    /// Used to translate user input 'A1' style into cartesian points.
    /// </summary>
    public class CoordinateTranslator : ICoordinateTranslator
    {
        /// <summary>
        /// Method to handle translation
        /// </summary>
        /// <param name="userInput">A string of user input, like 'A1'</param>
        /// <returns>A coordinate calculated from the users input.</returns>
        public Coordinate TranslateCoordinate(string userInput)
        {
            var splitInput = userInput.ToCharArray();

            if (splitInput.Length != 2)
            {
                throw new InvalidInputException("Coordinate must be 2 characters.");
            }

            if (!char.IsLetter(splitInput[0]))
            {
                throw new InvalidInputException("First character of coordinate must be a letter.");
            }

            if (!char.IsDigit(splitInput[1]))
            {
                throw new InvalidInputException("Second character of coordinate must be a number.");
            }

            return new Coordinate(char.ToUpper(splitInput[0]) - 64, (int)char.GetNumericValue(splitInput[1]));
        }
    }
}