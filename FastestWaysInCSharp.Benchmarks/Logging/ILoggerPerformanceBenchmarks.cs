using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Configs;
using FastestWaysInCSharp.Logging;

namespace FastestWaysInCSharp.Benchmarks.FileProcessing;

[Orderer(BenchmarkDotNet.Order.SummaryOrderPolicy.FastestToSlowest)]
[GroupBenchmarksBy(BenchmarkLogicalGroupRule.ByCategory, BenchmarkLogicalGroupRule.ByParams)]
[MemoryDiagnoser, DisassemblyDiagnoser(printInstructionAddresses: true, printSource: true, exportDiff: true)]
public class ILoggerPerformanceBenchmarks
{
    private readonly ILoggerPerformance _logger = new();

    [Benchmark]
    public void StringInterpolation() => _logger.StringInterpolation();

    [Benchmark(Baseline = true)]
    public void StructuredLogging() => _logger.StructuredLogging();

    [Benchmark]
    public void StructuredLoggingLevelChecking() => _logger.StructuredLoggingLevelChecking();

    [Benchmark]
    public void LoggerHelperDefine() => _logger.LoggerHelperDefine();

    [Benchmark]
    public void LoggerMessageSourceGenerator() => _logger.LoggerMessageSourceGenerator();

    [Benchmark]
    public void LoggerMessageStaticSourceGenerator() => _logger.LoggerMessageSourceGenerator();
}
