using System.Threading;

public sealed class UltimatumPlayer
{
    private static int NextId = 1;

    public int Id { get; } = Interlocked.Increment(ref NextId);
    public UltimatumStrategy Strategy { get; }
    public UltimatumPlayerState State { get; } = new UltimatumPlayerState();

    public UltimatumPlayer(UltimatumStrategy strategy) => Strategy = strategy;
}
