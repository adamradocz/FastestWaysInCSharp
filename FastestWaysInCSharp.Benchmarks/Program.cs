using BenchmarkDotNet.Running;
using FastestWaysInCSharp.Benchmarks.StringManipulation;

BenchmarkSwitcher benchmarkSwitcher = new(
    new[]
    {
        typeof(MultiSubstringBenchmarks),
        typeof(CharacterReplaceBenchmarks),
        typeof(ConvertStringToIntBenchmarks)
    });

benchmarkSwitcher.Run(args);
