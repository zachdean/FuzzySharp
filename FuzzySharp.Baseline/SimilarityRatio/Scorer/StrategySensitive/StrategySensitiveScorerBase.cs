using System;

namespace FuzzySharp.Baseline.SimilarityRatio.Scorer.StrategySensitive
{
    public abstract class StrategySensitiveScorerBase : ScorerBase
    {
        protected abstract Func<string, string, int> Scorer { get; }
    }
}
