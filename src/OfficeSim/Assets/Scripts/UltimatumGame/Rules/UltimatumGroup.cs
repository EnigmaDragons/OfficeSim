using System.Collections.Generic;
using System.Linq;

public sealed class UltimatumGroup
{
    public IEnumerable<UltimatumPlayer> Players { get; } 

    public UltimatumGroup(List<UltimatumPlayer> players)
    {
        Players = players;
    }

    public UltimatumPlayer[] Standings 
        => Players.OrderByDescending(p => p.State.Winnings).ToArray();
}
