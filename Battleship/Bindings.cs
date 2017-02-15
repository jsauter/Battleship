using Battleship.Game;
using Ninject.Modules;

namespace Battleship
{
    /// <summary>
    /// Bindings for interfaces and classes in the UI project
    /// </summary>
    public class Bindings : NinjectModule
    {
        public override void Load()
        {
            Bind<IGamePlayOrchestrator>().To<GamePlayOrchestrator>();
            Bind<ICoordinateTranslator>().To<CoordinateTranslator>();
            Bind<IBoardRenderer>().To<BoardRenderer>();
            Bind<ISettingService>().To<SettingService>();
        }
    }
}