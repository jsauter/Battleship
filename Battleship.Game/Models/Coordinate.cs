namespace Battleship.Game.Models
{
    public class Coordinate
    {
        public int X { get; protected set; }

        public int Y { get; protected set; }

        public Coordinate(int x, int y)
        {
            X = x;
            Y = y;
        }
    }
}