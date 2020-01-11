using System.Collections.Generic;
using System.Linq;

public sealed class UltimatumGroup
{
    public IEnumerable<UltimatumPlayer> Players { get; } 

    public UltimatumGroup(IEnumerable<UltimatumPlayer> players)
    {
        Players = players;
    }

    public UltimatumPlayer[] Standings 
        => Players.OrderBy(p => p.State.Winnings).ToArray();
}
