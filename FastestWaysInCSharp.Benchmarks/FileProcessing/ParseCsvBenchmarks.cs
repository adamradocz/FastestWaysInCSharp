using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Configs;
using FastestWaysInCSharp.FileProcessing.ParseCsv.V1;
using FastestWaysInCSharp.FileProcessing.ParseCsv.V2;
using FastestWaysInCSharp.FileProcessing.ParseCsv.V3;
using FastestWaysInCSharp.FileProcessing.ParseCsv.V4;
using FastestWaysInCSharp.FileProcessing.ParseCsv.V5CsvHelper;

namespace FastestWaysInCSharp.Benchmarks.FileProcessing;

[Orderer(BenchmarkDotNet.Order.SummaryOrderPolicy.FastestToSlowest)]
[GroupBenchmarksBy(BenchmarkLogicalGroupRule.ByCategory, BenchmarkLogicalGroupRule.ByParams)]
[MemoryDiagnoser, DisassemblyDiagnoser(printInstructionAddresses: true, printSource: true, exportDiff: true)]
public class ParseCsvBenchmarks
{
    public string FilePath { get; set; } = Path.Combine("FileProcessing", "ParseCsv", "FakeNames.csv");

    [BenchmarkCategory("Sync")]
    [Benchmark]
    public void V1StringArray()
    {
        foreach (var fakeName in StringArray.Parse(FilePath))
        {
        }
    }

    [BenchmarkCategory("Async")]
    [Benchmark]
    public async Task V1StringArrayAsync()
    {
        await foreach (var fakeName in StringArray.ParseAsync(FilePath))
        {
        }
    }

    [BenchmarkCategory("Sync")]
    [Benchmark]
    public void V2Span()
    {
        foreach (var fakeName in Span.Parse(FilePath))
        {
        }
    }

    [BenchmarkCategory("Async")]
    [Benchmark]
    public async Task V2SpanAsnyc()
    {
        await foreach (var fakeName in Span.ParseAsync(FilePath))
        {
        }
    }

    [BenchmarkCategory("Async")]
    [Benchmark]
    public async Task V3PipelinesAndSpanAsnyc() => _ = await PipelinesAndSpan.ParseAsync(FilePath);

    [BenchmarkCategory("Async")]
    [Benchmark]
    public async Task V4FilePipeReaderAndSpanAsnyc() => _ = await FilePipeReaderAndSpan.ParseAsync(FilePath);

    [BenchmarkCategory("Sync")]
    [Benchmark]
    public void V5CsvHelper()
    {
        foreach (var fakeName in CsvHelperParser.Parse(FilePath))
        {
        }
    }
}
