using System;
using System.Linq;
using System.Text;
using FuzzySharp.Extensions;

namespace FuzzySharp.SimilarityRatio.Scorer.StrategySensitive
{
    public abstract class TokenInitialismScorerBase : StrategySensitiveScorerBase
    {
        public override int Score(ReadOnlySpan<char> input1, ReadOnlySpan<char> input2)
        {
            ReadOnlySpan<char> shorter;
            ReadOnlySpan<char> longer;

            if (input1.Length < input2.Length)
            {
                shorter = input1;
                longer  = input2;
            }
            else
            {
                shorter = input2;
                longer  = input1;
            }

            double lenRatio = ((double)longer.Length) / shorter.Length;

            // if longer isn't at least 3 times longer than the other, then it's probably not an initialism
            if (lenRatio < 3) return 0;

            var sb = new StringBuilder(longer.Length);
            foreach (var c in longer.SplitWhiteSpace().Select(w => w[0]))
            {
                sb.Append(c);
            }

            return Scorer(sb.ToString(), shorter);
        }
    }
}
