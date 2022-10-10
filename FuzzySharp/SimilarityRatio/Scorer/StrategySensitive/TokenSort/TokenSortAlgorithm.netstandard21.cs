using FuzzySharp.Extensions;
using System;
using System.Linq;

namespace FuzzySharp.SimilarityRatio.Scorer.StrategySensitive
{
    public abstract class TokenSortScorerBase : StrategySensitiveScorerBase
    {
        public override int Score(ReadOnlySpan<char> input1, ReadOnlySpan<char> input2)
        {
            // TODO: fix splits
            var sorted1 = string.Join(" ", input1.SplitWhiteSpace().OrderBy(s => s)).Trim();
            var sorted2 = string.Join(" ", input2.SplitWhiteSpace().OrderBy(s => s)).Trim();

            return Scorer(sorted1, sorted2);
        }
    }
}
