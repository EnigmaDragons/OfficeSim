public sealed class UltimatumPlayer
{
    public UltimatumStrategy Strategy { get; }
    public UltimatumPlayerState State { get; } = new UltimatumPlayerState();

    public UltimatumPlayer(UltimatumStrategy strategy) => Strategy = strategy;
}
