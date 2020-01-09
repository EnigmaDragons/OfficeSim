using System.Collections.Generic;

public sealed class UltimatumGroup
{
    public IEnumerable<UltimatumPlayer> Players { get; } 

    public UltimatumGroup(IEnumerable<UltimatumPlayer> players)
    {
        Players = players;
    }
}
