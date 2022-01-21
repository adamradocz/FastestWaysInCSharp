using BenchmarkDotNet.Attributes;
using FastestWaysInCSharp.FileProcessing.ParseCsv.V1;

namespace FastestWaysInCSharp.Benchmarks.FileProcessing;

[Orderer(BenchmarkDotNet.Order.SummaryOrderPolicy.FastestToSlowest)]
[MemoryDiagnoser, DisassemblyDiagnoser(printInstructionAddresses: true, printSource: true, exportDiff: true)]
public class ParseCsvBenchmarks
{
    [ParamsSource(nameof(ValuesForCsvFilePath))]
    public string CsvFilePath { get; set; }

    public static IEnumerable<string> ValuesForCsvFilePath => new[]
    {
        Path.Combine("FileProcessing", "ParseCsv", "FakeNamesSmall.csv"),
        Path.Combine("FileProcessing", "ParseCsv", "FakeNamesLarge.csv")
    };

    [Benchmark]
    public void V1() => ReadLineSplit.Parse(CsvFilePath);


    [Benchmark]
    public void V2() => ReadLineSlice.Parse(CsvFilePath);
}
