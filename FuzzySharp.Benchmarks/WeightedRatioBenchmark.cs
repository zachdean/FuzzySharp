namespace FuzzySharp.Benchmarks;

[SimpleJob(RuntimeMoniker.NetCoreApp31)]
[SimpleJob(RuntimeMoniker.Net50)]
[SimpleJob(RuntimeMoniker.Net60)]
[MemoryDiagnoser]
public class WeightedRatioBenchmark
{
    [Benchmark]
    public int WeightedRatio() => Fuzz.WeightedRatio("The quick brown fox jimps ofver the small lazy dog",
        "the quick brown fox jumps over the small lazy dog");


    [Benchmark(Baseline = true)]
    public int BaselineWeightedRatio() => BaselineFuzz.WeightedRatio(
        "The quick brown fox jimps ofver the small lazy dog", "the quick brown fox jumps over the small lazy dog");

}