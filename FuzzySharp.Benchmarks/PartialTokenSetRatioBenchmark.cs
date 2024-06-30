namespace FuzzySharp.Benchmarks;

[SimpleJob(RuntimeMoniker.NetCoreApp31)]
[SimpleJob(RuntimeMoniker.Net50)]
[SimpleJob(RuntimeMoniker.Net60)]
[MemoryDiagnoser]
public class PartialTokenSetRatioBenchmark
{

    [Benchmark]
    public int PartialTokenSetRatio() => Fuzz.PartialTokenSetRatio("fuzzy was a bear", "fuzzy fuzzy fuzzy bear");

    [Benchmark(Baseline = true)]
    public int BaselinePartialTokenSetRatio() =>
        BaselineFuzz.PartialTokenSetRatio("fuzzy was a bear", "fuzzy fuzzy fuzzy bear");

}