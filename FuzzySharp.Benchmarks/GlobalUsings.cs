extern alias V3;
extern alias Baseline;
global using Fuzz = V3::FuzzySharp.Fuzz;
global using BaselineFuzz = Baseline::FuzzySharp.Fuzz;
global using BaselineStringPreprocessorFactory = Baseline::FuzzySharp.PreProcess.StringPreprocessorFactory;
global using BaselinePreprocessMode = Baseline::FuzzySharp.PreProcess.PreprocessMode;
global using V3::FuzzySharp.PreProcess;

global using BenchmarkDotNet.Attributes;
global using BenchmarkDotNet.Jobs;