using System.Collections.Generic;
using Battleship.Dependencies;
using Ninject;
using Ninject.Modules;

namespace Battleship
{
    /// <summary>
    /// Allows the bootstrapping of the game from the UI
    /// </summary>
    public class Bootstrapper
    {
        /// <summary>
        /// Initializes container modules and starts the game
        /// </summary>
        public void Bootstrap()
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