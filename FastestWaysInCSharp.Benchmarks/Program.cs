using BenchmarkDotNet.Running;
using FastestWaysInCSharp.Benchmarks.FileProcessing;
using FastestWaysInCSharp.Benchmarks.StringManipulation;

BenchmarkSwitcher benchmarkSwitcher = new(
    new[]
    {
        // StringManipulation
        typeof(MultiSubstringBenchmarks),
        typeof(CharacterReplaceBenchmarks),
        typeof(ConvertStringToIntBenchmarks),
        typeof(ConvertSubstringToIntBenchmarks),
        typeof(ParseByteArrayStringToIntBenchmarks),

        // FileProcessing
        typeof(ParseCsvBenchmarks),
        typeof(ParseJsonBenchmarks)
    });

benchmarkSwitcher.Run(args);
