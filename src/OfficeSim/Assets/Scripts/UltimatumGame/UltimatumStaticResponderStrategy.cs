public sealed class UltimatumStaticResponderStrategy : UltimatumResponseStrategy
{
    private float SkewTolerance { get; }

    public UltimatumStaticResponderStrategy(float skewTolerance) => SkewTolerance = skewTolerance;
    
    public bool Evaluate(float split) => SkewTolerance <= split;
}
