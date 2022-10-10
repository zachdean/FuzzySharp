using System;
using FuzzySharp.Baseline.SimilarityRatio.Strategy.Generic;

namespace FuzzySharp.Baseline.SimilarityRatio.Scorer.StrategySensitive.TokenDifference
{
    public class TokenDifferenceScorer : TokenDifferenceScorerBase
    {
        protected override Func<string[], string[], int> Scorer => DefaultRatioStrategy<string>.Calculate;
    }
}
