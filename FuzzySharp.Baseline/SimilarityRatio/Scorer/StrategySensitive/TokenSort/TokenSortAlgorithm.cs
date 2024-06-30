using FuzzySharp.SimilarityRatio.Scorer.StrategySensitive;
using System;
using System.Linq;
using System.Text.RegularExpressions;

namespace FuzzySharp.SimilarityRatio.Scorer.StrategySensitive.TokenSort
{
    public abstract class TokenSortScorerBase : StrategySensitiveScorerBase
    {
        public override int Score(string input1, string input2)
        {
            var sorted1 = string.Join(" ", Regex.Split(input1, @"\s+").Where(s => s.Any()).OrderBy(s => s)).Trim();
            var sorted2 = string.Join(" ", Regex.Split(input2, @"\s+").Where(s => s.Any()).OrderBy(s => s)).Trim();

            return Scorer(sorted1, sorted2);
        }
    }
}
