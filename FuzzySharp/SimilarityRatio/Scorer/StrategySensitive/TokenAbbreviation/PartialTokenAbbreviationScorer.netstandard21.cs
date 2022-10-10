using System;
using FuzzySharp.SimilarityRatio.Strategy;

namespace FuzzySharp.SimilarityRatio.Scorer.StrategySensitive
{
    public class PartialTokenAbbreviationScorer : TokenAbbreviationScorerBase
    {
        protected override StrategySensitiveScorerDelegate Scorer => PartialRatioStrategy.Calculate;
    }
}
