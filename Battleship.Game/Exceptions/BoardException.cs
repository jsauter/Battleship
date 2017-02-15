using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Battleship.Game.Exceptions
{
    public class BoardException : Exception
    {
        public BoardException(string message) : base(message)
        { 
            
        }
    }
}
