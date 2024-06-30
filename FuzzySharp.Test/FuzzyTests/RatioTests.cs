using FluentAssertions;
using FuzzySharp.PreProcess;
using NUnit.Framework;

namespace FuzzySharp.Test.FuzzyTests
{
    [TestFixture]
    public class RatioTests
    {
        #region Private Fields
        private string _s1,
                       _s1A,
                       _s2,
                       _s3,
                       _s4,
                       _s5,
                       _s6,
                       _s7,
                       _s8,
                       _s8A,
                       _s9,
                       _s9A,
                       _s10,
                       _s10A;

        private string[] _cirqueStrings, _baseballStrings;
        #endregion

        [SetUp]
        public void Setup()
        {
            _s1  = "new york mets";
            _s1A = "new york mets";
            _s2  = "new YORK mets";
            _s3  = "the wonderful new york mets";
            _s4  = "new york mets vs atlanta braves";
            _s5  = "atlanta braves vs new york mets";
            _s6  = "new york mets - atlanta braves";
            _s7  = "new york city mets - atlanta braves";
            // Edge cases
            _s8   = "{";
            _s8A  = "{";
            _s9   = "{a";
            _s9A  = "{a";
            _s10  = "a{";
            _s10A = "{b";
        }

        [Test]
        public void Test_Equal()
        {
            Fuzz.Ratio(_s1, _s1A).Should().Be(100);
            Fuzz.Ratio(_s8, _s8A).Should().Be(100);
            Fuzz.Ratio(_s9, _s9A).Should().Be(100);
        }

        [Test]
        public void Test_Case_Insensitive()
        {
            Fuzz.Ratio(_s1, _s2).Should().NotBe(100);
            Fuzz.Ratio(_s1, _s2, PreprocessMode.Full).Should().Be(100);
        }

        [Test]
        public void Test_Partial()
        {
            100.Should().Be(Fuzz.PartialRatio(_s1, _s3));
        }

        [Test]
        public void TestTokenSortRatio()
        {
            100.Should().Be(Fuzz.TokenSortRatio(_s1, _s1A));
        }

        [Test]
        public void TestPartialTokenSortRatio()
        {
            Fuzz.PartialTokenSortRatio(_s1, _s1A, PreprocessMode.Full).Should().Be(100);
            Fuzz.PartialTokenSortRatio(_s4, _s5, PreprocessMode.Full).Should().Be(100);
            Fuzz.PartialTokenSortRatio(_s8, _s8A).Should().Be(100);
            Fuzz.PartialTokenSortRatio(_s9, _s9A, PreprocessMode.Full).Should().Be(100);
            Fuzz.PartialTokenSortRatio(_s9, _s9A).Should().Be(100);
            Fuzz.PartialTokenSortRatio(_s10, _s10A).Should().Be(50);
        }

        [Test]
        public void TestTokenSetRatio()
        {
            Fuzz.TokenSetRatio(_s4, _s5, PreprocessMode.Full).Should().Be(100);
            Fuzz.TokenSetRatio(_s8, _s8A).Should().Be(100);
            Fuzz.TokenSetRatio(_s9, _s9A, PreprocessMode.Full).Should().Be(100);
            Fuzz.TokenSetRatio(_s9, _s9A).Should().Be(100);
            Fuzz.TokenSetRatio(_s10, _s10A).Should().Be(50);
        }

        [Test]
        public void TestTokenAbbreviationRatio()
        {
            Fuzz.TokenAbbreviationRatio("bl 420", "Baseline section 420", PreprocessMode.Full).Should().Be(40);
            Fuzz.PartialTokenAbbreviationRatio("bl 420", "Baseline section 420", PreprocessMode.Full).Should().Be(50);
        }

        [Test]
        public void TestPartialTokenSetRatio()
        {
            100.Should().Be(Fuzz.PartialTokenSetRatio(_s4, _s7));
        }

        [Test]
        public void TestWeightedRatioEqual()
        {
            100.Should().Be(Fuzz.WeightedRatio(_s1, _s1A));
        }

        [Test]
        public void TestWeightedRatioCaseInsensitive()
        {
            100.Should().Be(Fuzz.WeightedRatio(_s1, _s2, PreprocessMode.Full));
        }

        [Test]
        public void TestWeightedRatioPartialMatch()
        {
            90.Should().Be(Fuzz.WeightedRatio(_s1, _s3));
        }

        [Test]
        public void TestWeightedRatioMisorderedMatch()
        {
            95.Should().Be(Fuzz.WeightedRatio(_s4, _s5));
        }

        [Test]
        public void TestEmptyStringsScore0()
        {
            Assert.That(Fuzz.Ratio("test_string", ""), Is.EqualTo(0));
            Assert.That(Fuzz.PartialRatio("test_string", ""), Is.EqualTo(0));
            Assert.That(Fuzz.Ratio("", ""), Is.EqualTo(0));
            Assert.That(Fuzz.PartialRatio("", ""), Is.EqualTo(0));
        }

        [Test]
        public void TestIssueSeven()
        {
            _s1 = "HSINCHUANG";
            _s2 = "SINJHUAN";
            _s3 = "LSINJHUANG DISTRIC";
            _s4 = "SINJHUANG DISTRICT";

            Fuzz.PartialRatio(_s1, _s2).Should().BeGreaterThan(75);
            Fuzz.PartialRatio(_s1, _s3).Should().BeGreaterThan(75);
            Fuzz.PartialRatio(_s1, _s4).Should().BeGreaterThan(75);
        }

        [Test]
        public void TestIssueEight()
        {
            // https://github.com/JakeBayer/FuzzySharp/issues/8
            Fuzz.PartialRatio("Partnernummer", "Partne\nrnum\nmerASDFPartnernummerASDF").Should().Be(100); // was 85 
            Fuzz.PartialRatio("Partnernummer", "PartnerrrrnummerASDFPartnernummerASDF").Should().Be(100);  // was 77

            // https://github.com/xdrop/fuzzywuzzy/issues/39
            Fuzz.PartialRatio("kaution", "kdeffxxxiban:de1110010060046666666datum:16.11.17zeit:01:12uft0000899999tan076601testd.-20-maisonette-z4-jobas-hagkautionauszug").Should().Be(100); // was 57

            // https://github.com/seatgeek/fuzzywuzzy/issues/79
            Fuzz.PartialRatio("this is a test", "is this is a not really thing this is a test!").Should().Be(100); // was 92 (actually 93)
        }

        [Test]
        public void TestPartialRatioUnicodeString()
        {
            _s1 = "\u00C1";
            _s2 = "ABCD";
            var score = Fuzz.PartialRatio(_s1, _s2);
            score.Should().Be(0);
        }

        [Test]
        public void TestRatioUnicodeString()
        {
            _s1 = "\u00C1";
            _s2 = "ABCD";
            var score = Fuzz.WeightedRatio(_s1, _s2);
            score.Should().Be(0);

            // Cyrillic.
            _s1   = "\u043f\u0441\u0438\u0445\u043e\u043b\u043e\u0433";
            _s2   = "\u043f\u0441\u0438\u0445\u043e\u0442\u0435\u0440\u0430\u043f\u0435\u0432\u0442";
            score = Fuzz.WeightedRatio(_s1, _s2);
            score.Should().NotBe(0);

            // Chinese.
            _s1   = "\u6211\u4e86\u89e3\u6570\u5b66";
            _s2   = "\u6211\u5b66\u6570\u5b66";
            score = Fuzz.WeightedRatio(_s1, _s2);
            score.Should().NotBe(0);
        }
    }
}
