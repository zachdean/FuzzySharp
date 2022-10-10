using System;
using FuzzySharp.SimilarityRatio.Strategy;

namespace FuzzySharp.SimilarityRatio.Scorer.StrategySensitive
{
    public class PartialTokenInitialismScorer : TokenInitialismScorerBase
    {
        protected override StrategySensitiveScorerDelegate Scorer => PartialRatioStrategy.Calculate;
    }
}
