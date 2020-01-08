
public sealed class UltimatumStaticProposalStrategy : UltimatumProposalStrategy
{
    private float SkewAmount { get; }

    public UltimatumStaticProposalStrategy(float skewBias) => SkewAmount = skewBias;
    
    public float ProposeSplit() => SkewAmount;
}
