using System;
using System.Linq;

namespace FuzzySharp.Baseline.SimilarityRatio.Scorer.Composite
{
    public class WeightedRatioScorer : ScorerBase
    {
        private static double UNBASE_SCALE  = .95;
        private static double PARTIAL_SCALE = .90;
        private static bool TRY_PARTIALS = true;

        public override int Score(string input1, string input2)
        {
            int len1 = input1.Length;
            int len2 = input2.Length;

            if (len1 == 0 || len2 == 0)
            {
                return 0;
            }

            bool   tryPartials  = TRY_PARTIALS;
            double unbaseScale  = UNBASE_SCALE;
            double partialScale = PARTIAL_SCALE;

            int    baseRatio = BaselineFuzz.Ratio(input1, input2);
            double lenRatio  = ((double) Math.Max(len1, len2)) / Math.Min(len1, len2);

            // if strings are similar length don't use partials
            if (lenRatio < 1.5) tryPartials = false;

            // if one string is much shorter than the other
            if (lenRatio > 8) partialScale = .6;

            if (tryPartials)
            {
                double partial    = BaselineFuzz.PartialRatio(input1, input2) * partialScale;
                double partialSor = BaselineFuzz.TokenSortRatio(input1, input2) * unbaseScale * partialScale;
                double partialSet = BaselineFuzz.TokenSetRatio(input1, input2) * unbaseScale * partialScale;

                return (int) Math.Round(new[] { baseRatio, partial, partialSor, partialSet }.Max());
            }
            else
            {
                double tokenSort = BaselineFuzz.TokenSortRatio(input1, input2) * unbaseScale;
                double tokenSet  = BaselineFuzz.TokenSetRatio(input1, input2) * unbaseScale;

                return (int) Math.Round(new[] { baseRatio, tokenSort, tokenSet }.Max());
            }
        }

    }
}
