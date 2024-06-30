namespace FuzzySharp.Benchmarks;

[SimpleJob(RuntimeMoniker.NetCoreApp31)]
[SimpleJob(RuntimeMoniker.Net50)]
[SimpleJob(RuntimeMoniker.Net60)]
[MemoryDiagnoser]
public class PartialTokenSortBenchmark
{

    [Benchmark]
    public int PartialTokenSortRatio() => Fuzz.PartialTokenSortRatio("order words out of", "  words out of order");

    [Benchmark(Baseline = true)]
    public int BaselineTokenSortRatio() => BaselineFuzz.PartialRatio("similar", "somewhresimlrbetweenthisstring");
}