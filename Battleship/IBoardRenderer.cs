using Battleship.Game.Models;

namespace Battleship
{
    /// <summary>
    /// Interface representing a board renderer.
    /// </summary>
    public interface IBoardRenderer
    {
        string RenderBoard(Board board);
    }
}