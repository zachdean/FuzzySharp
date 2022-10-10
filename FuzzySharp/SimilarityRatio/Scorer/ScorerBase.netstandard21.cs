using FuzzySharp.PreProcess;
using System;

namespace FuzzySharp.SimilarityRatio.Scorer
{
    public abstract class ScorerBase : IRatioScorer
    {
        public abstract int Score(ReadOnlySpan<char> input1, ReadOnlySpan<char> input2);

        public int Score(ReadOnlySpan<char> input1, ReadOnlySpan<char> input2, PreprocessMode preprocessMode)
        {
            var preprocessor = StringPreprocessorFactory.GetPreprocessor(preprocessMode);
            input1 = preprocessor(input1);
            input2 = preprocessor(input2);
            return Score(input1, input2);
        }
    }
}
