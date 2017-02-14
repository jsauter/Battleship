namespace Battleship.Game.Models
{
    public interface IBoard
    {
        void PlaceShip(ShipBase ship);
        void FireShot(Coordinate coordinate);
    }
}