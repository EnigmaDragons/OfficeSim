public sealed class UltimateStrategyGeneration
{
    public static UltimatumStrategy Generate() => new UltimatumStrategy(
        new UltimatumStaticProposalStrategy(Rng.Float(0.01f, 0.99f)), 
        new UltimatumStaticResponderStrategy(Rng.Float(0.01f, 0.5f)));    
}
