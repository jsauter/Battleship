namespace Battleship.Game
{
    /// <summary>
    /// Interface that allows access to game settings
    /// </summary>
    public interface ISettingService
    {
        int BoardLength { get; }

        int BoardWidth { get; }

        int NumberOfPlayers { get; }
    }
}