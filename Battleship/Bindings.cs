using Ninject.Modules;

namespace Battleship
{
    public class Bindings : NinjectModule
    {
        public override void Load()
        {
            Bind<IGameOrchestrator>().To<GameOrchestrator>();
            Bind<ICoordinateTranslator>().To<CoordinateTranslator>();
        }
    }
}