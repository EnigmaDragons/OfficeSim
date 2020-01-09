public sealed class UltimateStrategyGeneration
{
    public static UltimatumStrategy Generate() => new UltimatumStrategy(new UltimatumStaticProposalStrategy(Rng.Float()), new UltimatumStaticResponderStrategy(Rng.Float()));    
}
