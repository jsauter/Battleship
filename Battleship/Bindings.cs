using Battleship.Game;
using Ninject.Modules;

namespace Battleship
{
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