namespace FuzzySharp.Benchmarks;

[SimpleJob(RuntimeMoniker.Net80)]
[MemoryDiagnoser]
public class FullPreProcessorBenchmark
{
    private const string PreprocessorFactory = "FuzzySharp.PreProcess.StringPreprocessorFactory";

    [Benchmark(Baseline = true)]
    public string BaselineFullPreprocessor() => BaselineStringPreprocessorFactory.GetPreprocessor(BaselinePreprocessMode.Full).Invoke(PreprocessorFactory);

    [Benchmark]
    public string FullPreprocessor() => StringPreprocessorFactory.GetPreprocessor(PreprocessMode.Full).Invoke(PreprocessorFactory);
}