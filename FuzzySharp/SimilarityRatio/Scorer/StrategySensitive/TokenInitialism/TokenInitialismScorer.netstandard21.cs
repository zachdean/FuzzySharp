using System;
using FuzzySharp.SimilarityRatio.Strategy;

namespace FuzzySharp.SimilarityRatio.Scorer.StrategySensitive
{
    public class TokenInitialismScorer : TokenInitialismScorerBase
    {
        protected override StrategySensitiveScorerDelegate Scorer => DefaultRatioStrategy.Calculate;
    }
}
