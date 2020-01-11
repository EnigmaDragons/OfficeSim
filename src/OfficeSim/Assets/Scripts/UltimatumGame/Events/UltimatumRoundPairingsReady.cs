using System.Collections.Generic;

public class UltimatumRoundPairingsReady
{
    public int RoundNumber { get; }
    public List<UltimatumRoundPairing> Pairings { get; }

    public UltimatumRoundPairingsReady(int roundNumber, List<UltimatumRoundPairing> pairings)
    {
        RoundNumber = roundNumber;
        Pairings = pairings;
    }
}
