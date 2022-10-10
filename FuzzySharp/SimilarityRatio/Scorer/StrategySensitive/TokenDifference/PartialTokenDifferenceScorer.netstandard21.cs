﻿using System;
using FuzzySharp.SimilarityRatio.Strategy.Generic;

namespace FuzzySharp.SimilarityRatio.Scorer.StrategySensitive
{
    public class PartialTokenDifferenceScorer : TokenDifferenceScorerBase
    {
        protected override Func<string[], string[], int> Scorer => (input1, input2) => PartialRatioStrategy<string>.Calculate(input1, input2);
    }
}
