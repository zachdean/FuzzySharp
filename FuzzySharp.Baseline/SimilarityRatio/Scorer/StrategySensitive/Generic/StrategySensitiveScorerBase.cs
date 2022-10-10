using System;
using FuzzySharp.Baseline.SimilarityRatio.Scorer.Generic;

namespace FuzzySharp.Baseline.SimilarityRatio.Scorer.StrategySensitive.Generic
{
    public abstract class StrategySensitiveScorerBase<T> : ScorerBase<T> where T : IEquatable<T>
    {
        protected abstract Func<T[], T[], int> Scorer { get; }
    }
}
