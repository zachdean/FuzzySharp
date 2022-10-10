﻿using System;
using System.Collections.Generic;
using System.Linq;
using FuzzySharp.Extensions;

namespace FuzzySharp.SimilarityRatio.Scorer.StrategySensitive
{
    public abstract class TokenSetScorerBase : StrategySensitiveScorerBase
    {
        public override int Score(ReadOnlySpan<char> input1, ReadOnlySpan<char> input2)
        {
            var tokens1 = new HashSet<string>(input1.SplitWhiteSpace());
            var tokens2 = new HashSet<string>(input2.SplitWhiteSpace());

            // TODO: optimize
            var sortedIntersection = String.Join(" ", tokens1.Intersect(tokens2).OrderBy(s => s)).Trim();
            var sortedDiff1To2     = (sortedIntersection + " " + String.Join(" ", tokens1.Except(tokens2).OrderBy(s => s))).Trim();
            var sortedDiff2To1     = (sortedIntersection + " " + String.Join(" ", tokens2.Except(tokens1).OrderBy(s => s))).Trim();

            return new[]
            {
                Scorer(sortedIntersection, sortedDiff1To2),
                Scorer(sortedIntersection, sortedDiff2To1),
                Scorer(sortedDiff1To2,     sortedDiff2To1)
            }.Max();
        }
    }
}
