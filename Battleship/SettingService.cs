using System.Configuration;
using Battleship.Game;

namespace Battleship
{
    /// <summary>
    /// A service that allows access to the app config to be injected
    /// </summary>
    public class SettingService : ISettingService
    {
        public int BoardLength { get; }

        public int BoardWidth { get; }

        public int NumberOfPlayers { get; }

        public SettingService()
        {
            var appSettings = ConfigurationManager.AppSettings;

            BoardLength = string.IsNullOrEmpty(appSettings["BoardLength"]) ? 8 : int.Parse(appSettings["BoardLength"]);
            BoardWidth = string.IsNullOrEmpty(appSettings["BoardWidth"]) ? 8 : int.Parse(appSettings["BoardWidth"]); 
            NumberOfPlayers = string.IsNullOrEmpty(appSettings["MaxNumberOfPlayers"]) ? 8 : int.Parse(appSettings["MaxNumberOfPlayers"]);
        }
    }
}