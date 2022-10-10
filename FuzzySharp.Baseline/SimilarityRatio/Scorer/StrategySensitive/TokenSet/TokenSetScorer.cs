using System;
using FuzzySharp.Baseline.SimilarityRatio.Strategy;

namespace FuzzySharp.Baseline.SimilarityRatio.Scorer.StrategySensitive.TokenSet
{
    public class TokenSetScorer : TokenSetScorerBase
    {
        protected override Func<string, string, int> Scorer => DefaultRatioStrategy.Calculate;
    }
}
