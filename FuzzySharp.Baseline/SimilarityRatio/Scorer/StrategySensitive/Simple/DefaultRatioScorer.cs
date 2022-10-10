using System;
using FuzzySharp.Baseline.SimilarityRatio.Strategy;

namespace FuzzySharp.Baseline.SimilarityRatio.Scorer.StrategySensitive.Simple
{
    public class DefaultRatioScorer : SimpleRatioScorerBase
    {
        protected override Func<string, string, int> Scorer => DefaultRatioStrategy.Calculate;
    }
}
