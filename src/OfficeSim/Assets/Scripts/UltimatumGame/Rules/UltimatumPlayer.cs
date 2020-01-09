using System.Threading;

public sealed class UltimatumPlayer
{
    private static int NextId = 0;

    public int Id { get; }
    public UltimatumStrategy Strategy { get; }
    public UltimatumPlayerState State { get; } = new UltimatumPlayerState();

    public UltimatumPlayer(UltimatumStrategy strategy)
    {
        Strategy = strategy;
        Id = Interlocked.Increment(ref NextId);
    }
}
