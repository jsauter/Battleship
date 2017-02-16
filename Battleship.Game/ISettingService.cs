namespace Battleship.Game
{
    /// <summary>
    /// Interface that allows access to game settings
    /// </summary>
    public interface ISettingService
    {
        int BoardHeight { get; }

        int BoardWidth { get; }

        int NumberOfPlayers { get; }
    }
}