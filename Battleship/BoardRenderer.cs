using System;
using System.Linq;
using System.Text;
using Battleship.Game;
using Battleship.Game.Models;

namespace Battleship
{
    /// <summary>
    /// Renders a textual representation of the player's board
    /// </summary>
    public class BoardRenderer : IBoardRenderer
    {
        private readonly ISettingService _settingService;

        public BoardRenderer(ISettingService settingService)
        {
            _settingService = settingService;
        }

        public string RenderBoard(Board board)
        {
            var boardState = board.GetBoardState();
            
            var stringBuilder = new StringBuilder();

            // write row header
            stringBuilder.Append("  ");

            for (int i = 1; i < _settingService.BoardWidth + 1; i++)
            {
                stringBuilder.Append(Convert.ToChar(i + 64) + " ");
            }

            stringBuilder.Append(Environment.NewLine);

            // go over the board rows
            for (int i = 1; i < _settingService.BoardHeight + 1; i++)
            {
                stringBuilder.Append($"{i} ");
                
                // go over the board columns
                for (int j = 1; j < _settingService.BoardWidth + 1; j++)
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