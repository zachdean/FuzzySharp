namespace FuzzySharp.Benchmarks;

[SimpleJob(RuntimeMoniker.NetCoreApp31)]
[SimpleJob(RuntimeMoniker.Net50)]
[SimpleJob(RuntimeMoniker.Net60)]
[MemoryDiagnoser]
public class TokenSetRatioBenchmark
{

    [Benchmark]
    public int TokenSetRatio() => Fuzz.TokenSetRatio("fuzzy was a bear", "fuzzy fuzzy fuzzy bear");

    [Benchmark(Baseline = true)]
    public int BaselineTokenSetRatio() => BaselineFuzz.TokenSetRatio("fuzzy was a bear", "fuzzy fuzzy fuzzy bear");
}