namespace FuzzySharp.Benchmarks;

[SimpleJob(RuntimeMoniker.NetCoreApp31)]
[SimpleJob(RuntimeMoniker.Net50)]
[SimpleJob(RuntimeMoniker.Net60)]
[MemoryDiagnoser]
public class TokenAbbreviationRatioBenchmark
{

    [Benchmark]
    public int TokenAbbreviationRatio() =>
        Fuzz.TokenAbbreviationRatio("bl 420", "Baseline section 420", PreprocessMode.Full);

    [Benchmark(Baseline = true)]
    public int BaselineTokenAbbreviationRatio() => BaselineFuzz.TokenAbbreviationRatio("bl 420",
        "Baseline section 420", BaselinePreprocessMode.Full);
}