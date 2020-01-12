
public sealed class UltimatumStaticProposalStrategy : UltimatumProposalStrategy
{
    private float SkewAmount { get; }

    public UltimatumStaticProposalStrategy(float skewBias) => SkewAmount = skewBias;

    public string Description()
    {
        var baseDesc = "";
        if (SkewAmount < 0.51f && SkewAmount > 0.49f)
            return $"{baseDesc} Fair";
        if (SkewAmount > 0.75f)
            return $"{baseDesc} Miserly";
        if (SkewAmount > 0.50f)
            return $"{baseDesc} Stingy";
        if (SkewAmount < 0.25f)
            return $"{baseDesc} Saintly";
        if (SkewAmount < 0.50f)
            return $"{baseDesc} Generous";
        return $"{baseDesc} Unknown";
    }

    public UltimatumOffer ProposeSplit(UltimatumPlayerState responder) => new UltimatumOffer(SkewAmount);
}
