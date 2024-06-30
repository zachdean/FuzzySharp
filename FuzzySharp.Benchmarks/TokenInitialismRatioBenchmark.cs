namespace FuzzySharp.Benchmarks;

[SimpleJob(RuntimeMoniker.NetCoreApp31)]
[SimpleJob(RuntimeMoniker.Net50)]
[SimpleJob(RuntimeMoniker.Net60)]
[MemoryDiagnoser]
public class TokenInitialismRatioBenchmark
{
    [Benchmark]
    public int TokenInitialismRatio() => Fuzz.TokenInitialismRatio("NASA",
        "National Aeronautics Space Administration, Kennedy Space Center, Cape Canaveral, Florida 32899");

    [Benchmark(Baseline = true)]
    public int BaselineTokenInitialismRatio() => BaselineFuzz.TokenInitialismRatio("NASA",
        "National Aeronautics Space Administration, Kennedy Space Center, Cape Canaveral, Florida 32899");
}