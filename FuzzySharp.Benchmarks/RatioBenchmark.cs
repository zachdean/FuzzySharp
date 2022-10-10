using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Jobs;
using FuzzySharp.Baseline;
using FuzzySharp.PreProcess;

namespace FuzzySharp.Benchmarks
{

    [SimpleJob(RuntimeMoniker.NetCoreApp31)]
    [SimpleJob(RuntimeMoniker.Net50)]
    [SimpleJob(RuntimeMoniker.Net60)]
    [MemoryDiagnoser]
    public class RatioBenchmark
    {

        [Benchmark(Baseline = true)]
        public int BaselineRatio() => BaselineFuzz.Ratio("mysmilarstring", "myawfullysimilarstirng");

        [Benchmark]
        public int Ratio() => Fuzz.Ratio("mysmilarstring", "myawfullysimilarstirng");
    }

    [SimpleJob(RuntimeMoniker.NetCoreApp31)]
    [SimpleJob(RuntimeMoniker.Net50)]
    [SimpleJob(RuntimeMoniker.Net60)]
    public class PartialRatioBenchmark
    {

        [Benchmark]
        public int PartialRatio() => Fuzz.PartialRatio("similar", "somewhresimlrbetweenthisstring");

        [Benchmark(Baseline = true)]
        public int BaselinePartialRatio() => BaselineFuzz.PartialRatio("similar", "somewhresimlrbetweenthisstring");
    }


    //[Benchmark]
    //    public int TokenSortRatio() => Fuzz.PartialRatio("similar", "somewhresimlrbetweenthisstring");

    //    [Benchmark]
    //    public int PartialTokenSortRatio() => Fuzz.PartialTokenSortRatio("order words out of", "  words out of order");

    //    [Benchmark]
    //    public int TokenSetRatio() => Fuzz.TokenSetRatio("fuzzy was a bear", "fuzzy fuzzy fuzzy bear");

    //    [Benchmark]
    //    public int PartialTokenSetRatio() => Fuzz.PartialTokenSetRatio("fuzzy was a bear", "fuzzy fuzzy fuzzy bear");

    //    [Benchmark]
    //    public int TokenInitialismRatio() => Fuzz.TokenInitialismRatio("NASA",
    //        "National Aeronautics Space Administration, Kennedy Space Center, Cape Canaveral, Florida 32899");

    //    [Benchmark]
    //    public int PartialTokenInitialismRatio() => Fuzz.PartialTokenInitialismRatio("NASA",
    //        "National Aeronautics Space Administration, Kennedy Space Center, Cape Canaveral, Florida 32899");

    //    [Benchmark]
    //    public int TokenAbbreviationRatio() =>
    //        Fuzz.TokenAbbreviationRatio("bl 420", "Baseline section 420", PreprocessMode.Full);

    //    [Benchmark]
    //    public int PartialTokenAbbreviationRatio() =>
    //        Fuzz.PartialTokenAbbreviationRatio("bl 420", "Baseline section 420", PreprocessMode.Full);

    //    [Benchmark]
    //    public int WeightedRatio() => Fuzz.WeightedRatio("The quick brown fox jimps ofver the small lazy dog",
    //        "the quick brown fox jumps over the small lazy dog");

    //    [Benchmark(Baseline = true)]
    //    public int BaselineTokenSortRatio() => BaselineFuzz.PartialRatio("similar", "somewhresimlrbetweenthisstring");

    //    [Benchmark(Baseline = true)]
    //    public int BaselinePartialTokenSortRatio() =>
    //        BaselineFuzz.PartialTokenSortRatio("order words out of", "  words out of order");

    //    [Benchmark(Baseline = true)]
    //    public int BaselineTokenSetRatio() => BaselineFuzz.TokenSetRatio("fuzzy was a bear", "fuzzy fuzzy fuzzy bear");

    //    [Benchmark(Baseline = true)]
    //    public int BaselinePartialTokenSetRatio() =>
    //        BaselineFuzz.PartialTokenSetRatio("fuzzy was a bear", "fuzzy fuzzy fuzzy bear");

    //    [Benchmark(Baseline = true)]
    //    public int BaselineTokenInitialismRatio() => BaselineFuzz.TokenInitialismRatio("NASA",
    //        "National Aeronautics Space Administration, Kennedy Space Center, Cape Canaveral, Florida 32899");

    //    [Benchmark(Baseline = true)]
    //    public int BaselinePartialTokenInitialismRatio() => BaselineFuzz.PartialTokenInitialismRatio("NASA",
    //        "National Aeronautics Space Administration, Kennedy Space Center, Cape Canaveral, Florida 32899");

    //    [Benchmark(Baseline = true)]
    //    public int BaselineTokenAbbreviationRatio() => BaselineFuzz.TokenAbbreviationRatio("bl 420",
    //        "Baseline section 420", Baseline.PreProcess.PreprocessMode.Full);

    //    [Benchmark(Baseline = true)]
    //    public int BaselinePartialTokenAbbreviationRatio() => BaselineFuzz.PartialTokenAbbreviationRatio("bl 420",
    //        "Baseline section 420", Baseline.PreProcess.PreprocessMode.Full);

    //    [Benchmark(Baseline = true)]
    //    public int BaselineWeightedRatio() => BaselineFuzz.WeightedRatio(
    //        "The quick brown fox jimps ofver the small lazy dog", "the quick brown fox jumps over the small lazy dog");

    //}
}