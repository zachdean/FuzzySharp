using System;
using FuzzySharp.SimilarityRatio.Strategy;

namespace FuzzySharp.SimilarityRatio.Scorer.StrategySensitive
{
    public class DefaultRatioScorer : SimpleRatioScorerBase
    {
        protected override Func<string, string, int> Scorer { get; } = DefaultRatioStrategy.Calculate;

        public static int ScoreStatic(string input1, string input2) => DefaultRatioStrategy.Calculate(input1, input2);

    }
}
