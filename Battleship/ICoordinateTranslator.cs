using Battleship.Game.Models;

namespace Battleship
{
    /// <summary>
    /// Interface representing a coordinate translator
    /// </summary>
    public interface ICoordinateTranslator
    {
        Coordinate TranslateCoordinate(string coordinateString);
    }
}