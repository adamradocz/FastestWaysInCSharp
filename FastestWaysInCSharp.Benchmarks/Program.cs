using BenchmarkDotNet.Running;
using FastestWaysInCSharp.Benchmarks.FileProcessing;
using FastestWaysInCSharp.Benchmarks.StringManipulation;

BenchmarkSwitcher benchmarkSwitcher = new(
    new[]
    {
        typeof(MultiSubstringBenchmarks),
        typeof(CharacterReplaceBenchmarks),
        typeof(ConvertStringToIntBenchmarks),
        typeof(ConvertSubstringToIntBenchmarks),
        typeof(ParseCsvBenchmarks)
    });

benchmarkSwitcher.Run(args);
