﻿using FuzzySharp.SimilarityRatio.Scorer.StrategySensitive;

namespace FuzzySharp.SimilarityRatio.Scorer.StrategySensitive.Simple
{
    public abstract class SimpleRatioScorerBase : StrategySensitiveScorerBase
    {
        public override int Score(string input1, string input2)
        {
            return Scorer(input1, input2);
        }
    }
}
