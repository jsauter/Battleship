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
            Bootstrap();
        }

        private static void Bootstrap()
        {
            var kernel = new StandardKernel(new Bindings());

            var modules = new List<INinjectModule>()
            {
                new GameBindings()
            };

            kernel.Load(modules);

            var gameOrchestrator = kernel.Get<IGamePlayOrchestrator>();

            gameOrchestrator.StartGame();
        }
    }
}
