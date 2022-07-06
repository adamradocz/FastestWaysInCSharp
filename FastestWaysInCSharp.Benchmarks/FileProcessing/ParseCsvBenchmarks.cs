using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Configs;
using FastestWaysInCSharp.FileProcessing.Model;
using FastestWaysInCSharp.FileProcessing.ParseCsv;
using FastestWaysInCSharp.FileProcessing.Utilities;

namespace FastestWaysInCSharp.Benchmarks.FileProcessing;

[Orderer(BenchmarkDotNet.Order.SummaryOrderPolicy.FastestToSlowest)]
[GroupBenchmarksBy(BenchmarkLogicalGroupRule.ByCategory, BenchmarkLogicalGroupRule.ByParams)]
[MemoryDiagnoser, DisassemblyDiagnoser(printInstructionAddresses: true, printSource: true, exportDiff: true)]
public class ParseCsvBenchmarks
{
    public static string FilePath => Data.GetCsvTestFilePath();

    [Benchmark]
    public async Task StringArrayAsync()
    {
        var fakeNames = new List<FakeName>();
        await foreach (var fakeName in StringArray.ParseAsync(FilePath))
        {
            fakeNames.Add(fakeName);
        }
    }

    [Benchmark]
    public async Task StringArrayAndChannelAsnyc() => _ = await StringArrayAndChannel.ParseAsync(FilePath);

    [Benchmark]
    public async Task SpanAsnyc()
    {
        var fakeNames = new List<FakeName>();
        await foreach (var fakeName in Span.ParseAsync(FilePath))
        {
            fakeNames.Add(fakeName);
        }
    }

    [Benchmark]
    public async Task PipeReaderAndSequenceReaderAsnyc() => _ = await PipeReaderAndSequenceReader.ParseAsync(FilePath);

    [Benchmark]
    public async Task FullPipeAndSequenceReaderAsnyc() => _ = await FullPipeAndSequenceReader.ParseAsync(FilePath);

    [Benchmark]
    public async Task FullPipeAndChannelAsnyc() => _ = await FullPipeAndChannel.ParseAsync(FilePath);

    [Benchmark]
    public async Task CsvHelperAsync()
    {
        var fakeNames = new List<FakeName>();
        await foreach (var fakeName in CsvHelperParser.ParseAsync(FilePath))
        {
            fakeNames.Add(fakeName);
        }
    }

    [Benchmark]
    public async Task SylvanDataCsvAsync()
    {
        var fakeNames = new List<FakeName>();
        await foreach (var fakeName in SylvanDataCsv.ParseAsync(FilePath))
        {
            fakeNames.Add(fakeName);
        }
    }
}
