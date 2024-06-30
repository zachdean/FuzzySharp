using FuzzySharp.Extensions;
using System;
using System.Linq;

namespace FuzzySharp.SimilarityRatio.Scorer.StrategySensitive
{
    public abstract class TokenSortScorerBase : StrategySensitiveScorerBase
    {
        public override int Score(string input1, string input2)
        {
            // TODO: optimize
            var sorted1 = string.Join(" ", input1.AsSpan().SplitWhiteSpace().OrderBy(s => s)).Trim();
            var sorted2 = string.Join(" ", input2.AsSpan().SplitWhiteSpace().OrderBy(s => s)).Trim();

            return Scorer(sorted1, sorted2);
        }
    }
}
