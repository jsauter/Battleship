using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Battleship.Game.Exceptions
{
    /// <summary>
    /// Exception to tell consumer that something went wrong with the board (i.e., too many boards, etc.)
    /// </summary>
    public class BoardException : Exception
    {
        public BoardException(string message) : base(message)
        { 
        }
    }
}
