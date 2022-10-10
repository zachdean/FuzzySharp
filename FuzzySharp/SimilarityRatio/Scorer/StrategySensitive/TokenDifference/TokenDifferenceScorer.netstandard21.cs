using System;
using FuzzySharp.SimilarityRatio.Strategy.Generic;

namespace FuzzySharp.SimilarityRatio.Scorer.StrategySensitive
{
    public class TokenDifferenceScorer : TokenDifferenceScorerBase
    {
        protected override Func<string[], string[], int> Scorer => (input1, input2) => DefaultRatioStrategy<string>.Calculate(input1, input2);
    }
}
