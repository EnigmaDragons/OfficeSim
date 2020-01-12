
public sealed class UltimatumStaticResponderStrategy : UltimatumResponseStrategy
{
    private float SkewTolerance { get; }

    public UltimatumStaticResponderStrategy(float skewTolerance) => SkewTolerance = skewTolerance;

    public string Description()
    {
        var baseDesc = $"";
        if (SkewTolerance < 0.10f)
            return $"{baseDesc} Permissive";
        if (SkewTolerance < 0.40f)
            return $"{baseDesc} Tolerant";
        if (SkewTolerance > 0.50f)
            return $"{baseDesc} Greedy";
        return $"{baseDesc} Defensive";
    }

    public bool Evaluate(UltimatumPlayerState proposer, UltimatumOffer split) => 1-(SkewTolerance) >= split.ProposerRatio;
}
