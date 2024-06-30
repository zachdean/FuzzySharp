namespace FuzzySharp.Benchmarks;

[SimpleJob(RuntimeMoniker.NetCoreApp31)]
[SimpleJob(RuntimeMoniker.Net50)]
[SimpleJob(RuntimeMoniker.Net60)]
[MemoryDiagnoser]
public class TokenSortRatioBenchmark
{

    [Benchmark]
    public int TokenSortRatio() => Fuzz.PartialRatio("similar", "somewhresimlrbetweenthisstring");

    [Benchmark(Baseline = true)]
    public int BaselineTokenSortRatio() => BaselineFuzz.PartialRatio("similar", "somewhresimlrbetweenthisstring");
}