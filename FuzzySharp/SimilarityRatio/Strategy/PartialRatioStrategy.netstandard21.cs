using System;
using System.Collections.Generic;
using System.Linq;
using FuzzySharp.Edits;

namespace FuzzySharp.SimilarityRatio.Strategy
{
    internal class PartialRatioStrategy
    {
        public static int Calculate(ReadOnlySpan<char> input1, ReadOnlySpan<char> input2)
        {
            ReadOnlySpan<char> shorter;
            ReadOnlySpan<char> longer;

            if (input1.Length == 0 || input2.Length == 0)
            {
                return 0;
            }

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

            MatchingBlock[] matchingBlocks = Levenshtein.GetMatchingBlocks(shorter, longer);

            List<double> scores = new List<double>();

            foreach (var matchingBlock in matchingBlocks)
            {
                int dist = matchingBlock.DestPos - matchingBlock.SourcePos;

                int longStart = dist > 0 ? dist : 0;
                int longEnd   = longStart + shorter.Length;

                if (longEnd > longer.Length) longEnd = longer.Length;

                ReadOnlySpan<char> longSubstr = longer.Slice(longStart, longEnd - longStart);

                double ratio = Levenshtein.GetRatio(shorter, longSubstr);

                if (ratio > .995)
                {
                    return 100;
                }

                scores.Add(ratio);

            }

            return (int)Math.Round(100 * scores.Max());
        }
    }
}
