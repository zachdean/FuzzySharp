using System;

namespace FuzzySharp.SimilarityRatio.Strategy.Generic
{
    internal class DefaultRatioStrategy<T> where T : IEquatable<T>
    {
        public static int Calculate(ReadOnlySpan<T> input1, ReadOnlySpan<T> input2)
        {
            if (input1.Length == 0 || input2.Length == 0)
            {
                return 0;
            }
            return (int) Math.Round(100 * Levenshtein.GetRatio(input1.ToArray(), input2.ToArray()));
        }
    }
}
