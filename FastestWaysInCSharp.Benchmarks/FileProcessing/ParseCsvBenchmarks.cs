using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Configs;
using FastestWaysInCSharp.FileProcessing.ParseCsv;
using FastestWaysInCSharp.FileProcessing.ParseCsv.Model;
using FastestWaysInCSharp.FileProcessing.ParseCsv.Utilities;

namespace FastestWaysInCSharp.Benchmarks.FileProcessing;

[Orderer(BenchmarkDotNet.Order.SummaryOrderPolicy.FastestToSlowest)]
[GroupBenchmarksBy(BenchmarkLogicalGroupRule.ByCategory, BenchmarkLogicalGroupRule.ByParams)]
[MemoryDiagnoser, DisassemblyDiagnoser(printInstructionAddresses: true, printSource: true, exportDiff: true)]
public class ParseCsvBenchmarks
{
    public static string FilePath => Data.GetTestFilePath();

    [Benchmark]
    [BenchmarkCategory("Sync")]
    public void StringArray()
    {
        var fakeNames = new List<FakeName>();
        foreach (var fakeName in FastestWaysInCSharp.FileProcessing.ParseCsv.StringArray.Parse(FilePath))
        {
            fakeNames.Add(fakeName);
        }
    }

    [Benchmark]
    [BenchmarkCategory("Async")]
    public async Task StringArrayAsync()
    {
        var fakeNames = new List<FakeName>();
        await foreach (var fakeName in FastestWaysInCSharp.FileProcessing.ParseCsv.StringArray.ParseAsync(FilePath))
        {
            fakeNames.Add(fakeName);
        }
    }

    [Benchmark]
    [BenchmarkCategory("Sync")]
    public void Span()
    {
        var fakeNames = new List<FakeName>();
        foreach (var fakeName in FastestWaysInCSharp.FileProcessing.ParseCsv.Span.Parse(FilePath))
        {
            fakeNames.Add(fakeName);
        }
    }

    [Benchmark]
    [BenchmarkCategory("Async")]
    public async Task SpanAsnyc()
    {
        var fakeNames = new List<FakeName>();
        await foreach (var fakeName in FastestWaysInCSharp.FileProcessing.ParseCsv.Span.ParseAsync(FilePath))
        {
            fakeNames.Add(fakeName);
        }
    }

    [Benchmark]
    [BenchmarkCategory("Async")]
    public async Task PipelinesAndSequenceReaderAsnyc() => _ = await PipelinesAndSequenceReader.ParseAsync(FilePath);

    [Benchmark]
    [BenchmarkCategory("Async")]
    public async Task PipelinesAndBufferReaderAsync() => _ = await PipelinesAndBufferReader.ParseAsync(FilePath);

    [Benchmark]
    [BenchmarkCategory("Sync")]
    public void CsvHelper()
    {
        var fakeNames = new List<FakeName>();
        foreach (var fakeName in CsvHelperParser.Parse(FilePath))
        {
            fakeNames.Add(fakeName);
        }
    }

    [Benchmark]
    [BenchmarkCategory("Async")]
    public async Task CsvHelperAsync()
    {
        var fakeNames = new List<FakeName>();
        await foreach (var fakeName in FastestWaysInCSharp.FileProcessing.ParseCsv.CsvHelperParser.ParseAsync(FilePath))
        {
            fakeNames.Add(fakeName);
        }
    }
}
