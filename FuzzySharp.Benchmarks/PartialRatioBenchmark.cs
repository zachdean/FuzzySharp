extern alias Baseline;

using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Jobs;


namespace FuzzySharp.Benchmarks;

[SimpleJob(RuntimeMoniker.NetCoreApp31)]
[SimpleJob(RuntimeMoniker.Net50)]
[SimpleJob(RuntimeMoniker.Net60)]
[MemoryDiagnoser]
public class PartialRatioBenchmark
{

    [Benchmark]
    public int PartialRatio() => Fuzz.PartialRatio("similar", "somewhresimlrbetweenthisstring");

    [Benchmark(Baseline = true)]
    public int BaselinePartialRatio() => BaselineFuzz.PartialRatio("similar", "somewhresimlrbetweenthisstring");
}