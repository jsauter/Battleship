namespace Battleship.Game.Models
{
    public interface IShip
    {
        bool IsHit(Coordinate shotCoordinate);
    }
}