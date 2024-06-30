extern alias Baseline;

namespace FuzzySharp.Benchmarks;

[SimpleJob(RuntimeMoniker.NetCoreApp31)]
[SimpleJob(RuntimeMoniker.Net50)]
[SimpleJob(RuntimeMoniker.Net60)]
[MemoryDiagnoser]
public class PartialTokenInitialismRatioBenchmark
{
    [Benchmark]
    public int PartialTokenInitialismRatio() => Fuzz.PartialTokenInitialismRatio("NASA",
        "National Aeronautics Space Administration, Kennedy Space Center, Cape Canaveral, Florida 32899");

    [Benchmark(Baseline = true)]
    public int BaselinePartialTokenInitialismRatio() => BaselineFuzz.PartialTokenInitialismRatio("NASA",
        "National Aeronautics Space Administration, Kennedy Space Center, Cape Canaveral, Florida 32899");
}