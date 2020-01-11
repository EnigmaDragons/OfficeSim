
public sealed class UltimatumStaticProposalStrategy : UltimatumProposalStrategy
{
    private float SkewAmount { get; }

    public UltimatumStaticProposalStrategy(float skewBias) => SkewAmount = skewBias;

    public string Description()
    {
        var baseDesc = "";
        if (SkewAmount < 51 && SkewAmount > 49)
            return $"{baseDesc} Fair";
        if (SkewAmount > 75)
            return $"{baseDesc} Miserly";
        if (SkewAmount > 50)
            return $"{baseDesc} Stingy";
        if (SkewAmount < 25)
            return $"{baseDesc} Saintly";
        if (SkewAmount < 50)
            return $"{baseDesc} Generous";
        return $"{baseDesc} Unknown";
    }

    public float ProposeSplit() => SkewAmount;
}
