using System;
using FuzzySharp.SimilarityRatio.Strategy;

namespace FuzzySharp.SimilarityRatio.Scorer.StrategySensitive
{
    public class PartialRatioScorer : SimpleRatioScorerBase
    {
        protected override StrategySensitiveScorerDelegate Scorer => PartialRatioStrategy.Calculate;
    }
}
