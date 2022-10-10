using System;
using FuzzySharp.Baseline.SimilarityRatio.Strategy;

namespace FuzzySharp.Baseline.SimilarityRatio.Scorer.StrategySensitive.TokenSort
{
    public class PartialTokenSortScorer : TokenSortScorerBase
    {
        protected override Func<string, string, int> Scorer => PartialRatioStrategy.Calculate;
    }
}
