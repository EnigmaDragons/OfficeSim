using System.Collections.Generic;

namespace Characters.Personality
{
    public sealed class ConfidenceLevel
    {
        private static readonly List<Weighted<float>> ConfidenceDistribution = new List<Weighted<float>>
        {
            new Weighted<float>(1, 0.1f),
            new Weighted<float>(2, 0.2f),
            new Weighted<float>(3, 0.3f),
            new Weighted<float>(6, 0.4f),
            new Weighted<float>(10, 0.5f),
            new Weighted<float>(18, 0.6f),
            new Weighted<float>(37, 0.7f),
            new Weighted<float>(18, 0.8f),
            new Weighted<float>(4, 0.9f),
            new Weighted<float>(1, 1f)
        };
        
        public static CharacterScalarTrait Random() 
            => new CharacterScalarTrait { Name = "Confidence", Value = ConfidenceDistribution.Weighted().Random()}; 
    }
}
