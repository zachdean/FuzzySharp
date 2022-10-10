using System;

namespace FuzzySharp.SimilarityRatio.Scorer.StrategySensitive
{
    public delegate int StrategySensitiveScorerDelegate(ReadOnlySpan<char> input1, ReadOnlySpan<char> input2);
    
    public abstract class StrategySensitiveScorerBase : ScorerBase
    {
        protected abstract StrategySensitiveScorerDelegate Scorer { get; }
    }
}
