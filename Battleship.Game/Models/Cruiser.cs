namespace Battleship.Game.Models
{
    /// <summary>
    /// A cruiser is a three hit ship type.  
    /// </summary>
    public class Cruiser : ShipBase
    {
        public Cruiser(Coordinate start, Coordinate end) : base(start, end, 3)
        {
            Name = "Cruiser";
        }
    }
}