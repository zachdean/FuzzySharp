using System;
using BenchmarkDotNet.Running;

namespace FuzzySharp.Benchmarks;

internal class Program
{
    static void Main(string[] args)
    {
        var benchmark = new RatioBenchmark();
        for (int i = 0; i < 100_000_000; i++)
        {
            var result = benchmark.Ratio();
        }

        //var summary = BenchmarkRunner.Run<RatioBenchmark>();
        //Console.WriteLine(summary);
        ////summary = BenchmarkRunner.Run<PartialRatioBenchmark>();
        ////Console.WriteLine(summary);
        //Console.ReadKey();
    }
}