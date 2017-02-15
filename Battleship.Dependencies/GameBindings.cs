using Battleship.Game;
using Ninject.Modules;

namespace Battleship.Dependencies
{
    /// <summary>
    /// Bindings for injectable interfaces and classes in the Battleship.Game project.
    /// </summary>
    public class GameBindings : NinjectModule
    {
        public override void Load()
        {
            Bind<IGameState>().To<GameState>().InSingletonScope();
        }
    }
}