namespace Battleship.Game.Models
{
    /// <summary>
    /// A cruiser is a three hit ship type.  
    /// </summary>
    public class Cruiser : ShipBase
    {
        /// <summary>
        /// Creating a cruiser provides it with a name string of 'Cruiser'
        /// </summary>
        /// <param name="start">The start placement of the cruiser</param>
        /// <param name="end">The end placement of the cruiser</param>
        public Cruiser(Coordinate start, Coordinate end) : base(start, end, 3)
        {
            Name = "Cruiser";
        }
    }
}