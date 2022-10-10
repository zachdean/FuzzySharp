using FuzzySharp.SimilarityRatio.Strategy;

namespace FuzzySharp.SimilarityRatio.Scorer.StrategySensitive
{
    public class TokenSetScorer : TokenSetScorerBase
    {
        protected override StrategySensitiveScorerDelegate Scorer => DefaultRatioStrategy.Calculate;
    }
}
