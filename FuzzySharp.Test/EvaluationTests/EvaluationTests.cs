using FuzzySharp.PreProcess;
using FuzzySharp.SimilarityRatio;
using FuzzySharp.SimilarityRatio.Scorer.Composite;
using FuzzySharp.SimilarityRatio.Scorer.StrategySensitive;
using NUnit.Framework;

namespace FuzzySharp.Test.EvaluationTests
{
    [TestFixture]
    public class EvaluationTests
    {
        [Test]
        public void EvaluateRatio1()
        {
            var a1 = Fuzz.Ratio("mysmilarstring", "myawfullysimilarstirng");
        }

        [Test]
        public void EvaluateRatio2()
        {
            var a2 = Fuzz.Ratio("mysmilarstring", "mysimilarstring");
        }

        [Test]
        public void EvaluatePartialRatio()
        {
            var b1 = Fuzz.PartialRatio("similar", "somewhresimlrbetweenthisstring");
        }

        [Test]
        public void EvaluateTokenSortRatio()
        {
            var c1 = Fuzz.TokenSortRatio("order words out of", "  words out of order");
        }

        [Test]
        public void EvaluatePartialTokenSortRatio()
        {
            var c2 = Fuzz.PartialTokenSortRatio("order words out of", "  words out of order");
        }

        [Test]
        public void EvaluateTokenSetRatio()
        {
            var d1 = Fuzz.TokenSetRatio("fuzzy was a bear", "fuzzy fuzzy fuzzy bear");
        }

        [Test]
        public void EvaluatePartialTokenSetRatio()
        {
            var d2 = Fuzz.PartialTokenSetRatio("fuzzy was a bear", "fuzzy fuzzy fuzzy bear");
        }

        [Test]
        public void EvaluateWeightedRatio()
        {
            var e1 = Fuzz.WeightedRatio("The quick brown fox jimps ofver the small lazy dog", "the quick brown fox jumps over the small lazy dog");
            Assert.AreEqual(95, e1);
        }

        [Test]
        public void EvaluateTokenInitialismRatio()
        {
            var f1 = Fuzz.TokenInitialismRatio("NASA", "National Aeronautics and Space Administration");
        }

        [Test]
        public void EvaluateTokenInitialismRatio2()
        {
            var f2 = Fuzz.TokenInitialismRatio("NASA", "National Aeronautics Space Administration");
        }

        [Test]
        public void EvaluateTokenInitialismRatio3()
        {
            var f3 = Fuzz.TokenInitialismRatio("NASA", "National Aeronautics Space Administration, Kennedy Space Center, Cape Canaveral, Florida 32899");
        }

        [Test]
        public void EvaluateTokenInitialismRatio4()
        {
            var f4 = Fuzz.PartialTokenInitialismRatio("NASA", "National Aeronautics Space Administration, Kennedy Space Center, Cape Canaveral, Florida 32899");
        }

        [Test]
        public void EvaluateTokenAbbreviationRatio()
        {
            var g1 = Fuzz.TokenAbbreviationRatio("bl 420", "Baseline section 420", PreprocessMode.Full);
        }

        [Test]
        public void EvaluatePartialTokenAbbreviationRatio()
        {
            var g2 = Fuzz.PartialTokenAbbreviationRatio("bl 420", "Baseline section 420", PreprocessMode.Full);
        }

        [Test]
        public void EvaluateExtractOne()
        {
            var h1 = Process.ExtractOne("cowboys", new[] { "Atlanta Falcons", "New York Jets", "New York Giants", "Dallas Cowboys" });
        }

        [Test]
        public void EvaluateExtractTop()
        {
            var h2 = string.Join(", ", Process.ExtractTop("goolge", new[] { "google", "bing", "facebook", "linkedin", "twitter", "googleplus", "bingnews", "plexoogl" }, limit: 3));
        }

        [Test] 
        public void EvaluateExtractAll()
        {
            var h3 = string.Join(", ", Process.ExtractAll("goolge", new[] { "google", "bing", "facebook", "linkedin", "twitter", "googleplus", "bingnews", "plexoogl" }));
        }

        [Test]
        public void EvaluateExtractAll2()
        {
            var h4 = string.Join(", ", Process.ExtractAll("goolge", new[] { "google", "bing", "facebook", "linkedin", "twitter", "googleplus", "bingnews", "plexoogl" }, cutoff: 40));
        }

        [Test]
        public void EvaluateExtractSorted()
        {
            var h5 = string.Join(", ", Process.ExtractSorted("goolge", new[] { "google", "bing", "facebook", "linkedin", "twitter", "googleplus", "bingnews", "plexoogl" }));
        }

        [Test]
        public void EvaluateExtractBest()
        {
            var events = new[]
            {
                new[] { "chicago cubs vs new york mets", "CitiField", "2011-05-11", "8pm" },
                new[] { "new york yankees vs boston red sox", "Fenway Park", "2011-05-11", "8pm" },
                new[] { "atlanta braves vs pittsburgh pirates", "PNC Park", "2011-05-11", "8pm" },
            };
            var query = new[] { "new york mets vs chicago cubs", "CitiField", "2017-03-19", "8pm" };

            var best = Process.ExtractOne(query, events, strings => strings[0]);
        }

        [Test]
        public void EvaluateExtractOne2()
        {
            var i1 = Process.ExtractOne("cowboys", new[] { "Atlanta Falcons", "New York Jets", "New York Giants", "Dallas Cowboys" }, s => s, ScorerCache.Get<DefaultRatioScorer>());
        }


        [Test]
        public void Evaluate()
        {
            var ratio = ScorerCache.Get<DefaultRatioScorer>();
            var partial = ScorerCache.Get<PartialRatioScorer>();
            var tokenSet = ScorerCache.Get<TokenSetScorer>();
            var partialTokenSet = ScorerCache.Get<PartialTokenSetScorer>();
            var tokenSort = ScorerCache.Get<TokenSortScorer>();
            var partialTokenSort = ScorerCache.Get<PartialTokenSortScorer>();
            var tokenAbbreviation = ScorerCache.Get<TokenAbbreviationScorer>();
            var partialTokenAbbreviation = ScorerCache.Get<PartialTokenAbbreviationScorer>();
            var weighted = ScorerCache.Get<WeightedRatioScorer>();
        }

        [Test]
        public void TokenInitialismScorer_WhenGivenStringWithTrailingSpaces_DoesNotBreak()
        {
            // arrange
            var longer = "lusiki plaza share block ";
            var shorter = "jmft";

            // act
            var ratio = Fuzz.TokenInitialismRatio(shorter, longer);

            // assert
            Assert.IsTrue(ratio >= 0);
        }
    }
}
