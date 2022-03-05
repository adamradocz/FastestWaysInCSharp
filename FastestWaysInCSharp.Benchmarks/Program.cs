using BenchmarkDotNet.Running;
using FastestWaysInCSharp.Benchmarks.Enums;
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
        typeof(StringConcatenationBenchmarks),

        // RegularExpressions
        typeof(RegularExpressionsBenchmarks),

        // FileProcessing
        typeof(ParseCsvBenchmarks),
        typeof(SerializeJsonBenchmarks),

        // Logging
        typeof(ILoggerPerformanceBenchmarks),

        // Factory
        typeof(FactoryBenchmarks),

        //Enums
        typeof(EnumBenchmarks)
    });

benchmarkSwitcher.Run(args);
