using System;
using BenchmarkDotNet.Running;

namespace FuzzySharp.Benchmarks
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var summary = BenchmarkRunner.Run<RatioBenchmark>();
            Console.WriteLine(summary);
            summary = BenchmarkRunner.Run<PartialRatioBenchmark>();
            Console.WriteLine(summary);
            Console.ReadKey();
        }
    }
}