using BenchmarkDotNet.Attributes;
using FastestWaysInCSharp.FileProcessing.ParseCsv.V1;

namespace FastestWaysInCSharp.Benchmarks.FileProcessing;

[Orderer(BenchmarkDotNet.Order.SummaryOrderPolicy.FastestToSlowest)]
[MemoryDiagnoser, DisassemblyDiagnoser(printInstructionAddresses: true, printSource: true, exportDiff: true)]
public class ParseCsvBenchmarks
{
    private readonly string _smallCsvFilePath;
    private readonly string _largeCsvFilePath;

    public ParseCsvBenchmarks()
    {
        _smallCsvFilePath = Path.Combine("FileProcessing", "ParseCsv", "FakeNamesSmall.csv");
        _largeCsvFilePath = Path.Combine("FileProcessing", "ParseCsv", "FakeNamesLarge.csv");
    }

    [Benchmark]
    public void V1() => new ReadLineSplit().Parse(_smallCsvFilePath);
}
