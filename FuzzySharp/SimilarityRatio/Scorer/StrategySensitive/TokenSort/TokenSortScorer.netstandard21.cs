using System;
using FuzzySharp.SimilarityRatio.Strategy;

namespace FuzzySharp.SimilarityRatio.Scorer.StrategySensitive
{
    public class TokenSortScorer : TokenSortScorerBase
    {
        protected override StrategySensitiveScorerDelegate Scorer => DefaultRatioStrategy.Calculate;
    }
}
