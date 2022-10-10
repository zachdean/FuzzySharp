using System;
using FuzzySharp.Baseline.SimilarityRatio.Strategy.Generic;

namespace FuzzySharp.Baseline.SimilarityRatio.Scorer.StrategySensitive.TokenDifference
{
    public class PartialTokenDifferenceScorer : TokenDifferenceScorerBase
    {
        protected override Func<string[], string[], int> Scorer => PartialRatioStrategy<string>.Calculate;
    }
}
