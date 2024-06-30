namespace FuzzySharp.Benchmarks
{

    //[SimpleJob(RuntimeMoniker.NetCoreApp31)]
    //[SimpleJob(RuntimeMoniker.Net50)]
    [SimpleJob(RuntimeMoniker.Net80)]
    [MemoryDiagnoser]
    public class RatioBenchmark
    {
        private const string String1 = "mysmilarstring";
        private const string String2 = "myawfullysimilarstirng";

        [Benchmark(Baseline = true)]
        public int BaselineRatio() => BaselineFuzz.Ratio(String1, String2);

        [Benchmark]
        public int Ratio() => Fuzz.Ratio(String1, String2);
    }
}