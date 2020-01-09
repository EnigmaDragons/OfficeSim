using System.Collections.Generic;
using UnityTemplateProjects.UltimatumGame;

public class UltimatumRoundPairingsReady
{
    public List<UltimatumRoundPairing> Pairings { get; }

    public UltimatumRoundPairingsReady(List<UltimatumRoundPairing> pairings)
    {
        Pairings = pairings;
    }
}
