using Battleship.Game.Models;

namespace Battleship
{
    public interface ICoordinateTranslator
    {
        Coordinate TranslateCoordinate(string coordinateString);
    }
}