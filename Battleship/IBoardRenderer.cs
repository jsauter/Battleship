using Battleship.Game.Models;

namespace Battleship
{
    /// <summary>
    /// Interface reprsenting a board renderer.
    /// </summary>
    public interface IBoardRenderer
    {
        void RenderBoard(Board board);
    }
}