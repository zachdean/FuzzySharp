using FuzzySharp.SimilarityRatio.Strategy;

namespace FuzzySharp.SimilarityRatio.Scorer.StrategySensitive
{
    public class PartialTokenSetScorer : TokenSetScorerBase
    {
        protected override StrategySensitiveScorerDelegate Scorer => PartialRatioStrategy.Calculate;
    }
}
