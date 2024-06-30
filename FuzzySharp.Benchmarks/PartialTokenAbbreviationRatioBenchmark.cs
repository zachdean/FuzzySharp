namespace FuzzySharp.Benchmarks;

[SimpleJob(RuntimeMoniker.NetCoreApp31)]
[SimpleJob(RuntimeMoniker.Net50)]
[SimpleJob(RuntimeMoniker.Net60)]
[MemoryDiagnoser]
public class PartialTokenAbbreviationRatioBenchmark
{

    [Benchmark]
    public int PartialTokenAbbreviationRatio() =>
        Fuzz.PartialTokenAbbreviationRatio("bl 420", "Baseline section 420", PreprocessMode.Full);


    [Benchmark(Baseline = true)]
    public int BaselinePartialTokenAbbreviationRatio() => BaselineFuzz.PartialTokenAbbreviationRatio("bl 420",
        "Baseline section 420", BaselinePreprocessMode.Full);
}