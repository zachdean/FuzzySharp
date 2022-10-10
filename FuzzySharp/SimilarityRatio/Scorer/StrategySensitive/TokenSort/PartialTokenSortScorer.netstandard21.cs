using System;
using FuzzySharp.SimilarityRatio.Strategy;

namespace FuzzySharp.SimilarityRatio.Scorer.StrategySensitive
{
    public class PartialTokenSortScorer : TokenSortScorerBase
    {
        protected override StrategySensitiveScorerDelegate Scorer => PartialRatioStrategy.Calculate;
    }
}
