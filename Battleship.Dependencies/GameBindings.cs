using Battleship.Game;
using Ninject.Modules;

namespace Battleship.Dependencies
{
    public class GameBindings : NinjectModule
    {
        public override void Load()
        {
            Bind<IGameState>().To<GameState>();
        }
    }
}