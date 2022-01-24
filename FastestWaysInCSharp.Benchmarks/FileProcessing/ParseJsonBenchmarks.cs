using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Configs;
using FastestWaysInCSharp.FileProcessing.Model;
using FastestWaysInCSharp.FileProcessing.ParseJson;
using FastestWaysInCSharp.FileProcessing.Utilities;

namespace FastestWaysInCSharp.Benchmarks.FileProcessing;

[Orderer(BenchmarkDotNet.Order.SummaryOrderPolicy.FastestToSlowest)]
[GroupBenchmarksBy(BenchmarkLogicalGroupRule.ByCategory, BenchmarkLogicalGroupRule.ByParams)]
[MemoryDiagnoser, DisassemblyDiagnoser(printInstructionAddresses: true, printSource: true, exportDiff: true)]
public class ParseJsonBenchmarks
{
    public static string FilePath => Data.GetJsonTestFilePath();

    [Benchmark]
    [BenchmarkCategory("Async")]
    public async Task SystemTextJsonAsync()
    {
        var fakeNames = new List<FakeName>();
        await foreach (var fakeName in SystemTextJson.ParseAsync(FilePath))
        {
            fakeNames.Add(fakeName);
        }
    }
}
