
public sealed class UltimatumStaticResponderStrategy : UltimatumResponseStrategy
{
    private float SkewTolerance { get; }

    public UltimatumStaticResponderStrategy(float skewTolerance) => SkewTolerance = skewTolerance;

    public string Description()
    {
        var baseDesc = "";
        if (SkewTolerance > 0.90f)
            return $"{baseDesc} Permissive";
        if (SkewTolerance > 0.50f)
            return $"{baseDesc} Tolerant";
        return "Defensive";
    }

    public bool Evaluate(UltimatumPlayerState proposer, UltimatumOffer split) => 1-(SkewTolerance) >= split.ProposerRatio;
}
