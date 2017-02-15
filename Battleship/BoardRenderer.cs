using System;
using System.Linq;
using System.Text;
using Battleship.Game.Models;

namespace Battleship
{

    /// <summary>
    /// Renders a textual representation of the player's board
    /// </summary>
    public class BoardRenderer : IBoardRenderer
    {
        public string RenderBoard(Board board)
        {
            var boardState = board.GetBoardState();
            
            var stringBuilder = new StringBuilder();

            stringBuilder.Append("  A B C D E F G H");
            stringBuilder.Append(Environment.NewLine);

            for (int i = 1; i < 9; i++)
            {
                stringBuilder.Append($"{i} ");
                
                for (int j = 1; j < 9; j++)
                {
                    var shot = boardState.Where(x => x.Key.X == j && x.Key.Y == i).Take(1).ToList();

                    if (shot.Count == 1)
                    {
                        stringBuilder.Append(shot[0].Value == ShotResult.Hit ? "S " : "X ");
                    }
                    else
                    {
                        stringBuilder.Append("- ");
                    }
                }

                stringBuilder.Append(Environment.NewLine);
            }

            return stringBuilder.ToString();
        }
    }
}