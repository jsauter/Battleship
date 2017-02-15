using System.Collections.Generic;
using Battleship.Dependencies;
using Ninject;
using Ninject.Modules;

namespace Battleship
{
    class Program
    {
        static void Main(string[] args)
        {
            var bootStrapper = new Bootstrapper();

            bootStrapper.Bootstrap();
        }        
    }
}
