using FuzzySharp.PreProcess;
using System;

namespace FuzzySharp.SimilarityRatio.Scorer
{
    public interface IRatioScorer
    {
        int Score(ReadOnlySpan<char> input1, ReadOnlySpan<char> input2);
        int Score(ReadOnlySpan<char> input1, ReadOnlySpan<char> input2, PreprocessMode preprocessMode);
    }
}
