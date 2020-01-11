
public sealed class UltimatumStaticResponderStrategy : UltimatumResponseStrategy
{
    private float SkewTolerance { get; }

    public UltimatumStaticResponderStrategy(float skewTolerance) => SkewTolerance = skewTolerance;

    public string Description()
    {
        var baseDesc = "";
        if (SkewTolerance > 90)
            return $"{baseDesc} Permissive";
        if (SkewTolerance > 50)
            return $"{baseDesc} Tolerant";
        return "Defensive";
    }

    public bool Evaluate(float split) => 1-(SkewTolerance) >= split;
}
