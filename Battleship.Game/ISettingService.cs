namespace Battleship.Game
{
    public interface ISettingService
    {
        int BoardLength { get; }

        int BoardWidth { get; }

        int NumberOfPlayers { get; }
    }
}