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

    private List<FakeName> _fakeNames;

    [GlobalSetup]
    public async Task GlobalSetupAsync()
    {
        _fakeNames = await SystemTextJsonSourceGenerated.DeserializeAsync(FilePath);
    }

    [Benchmark]
    [BenchmarkCategory("Deserialize")]
    public async Task SystemTextJsonDeserializeAsync()
    {
        var fakeNames = new List<FakeName>();
        await foreach (var fakeName in SystemTextJson.DeserializeAsyncEnumerable(FilePath))
        {
            fakeNames.Add(fakeName);
        }
    }

    [Benchmark]
    [BenchmarkCategory("Deserialize")]
    public async Task SystemTextJsonSrcGenDeserializeAsync()
    {
        var fakeNames = new List<FakeName>();
        await foreach (var fakeName in SystemTextJsonSourceGenerated.DeserializeAsyncEnumerable(FilePath))
        {
            fakeNames.Add(fakeName);
        }
    }

    [Benchmark]
    [BenchmarkCategory("Serialize")]
    public string SystemTextJsonSerialize() => SystemTextJson.Serialize(_fakeNames);

    [Benchmark]
    [BenchmarkCategory("Serialize")]
    public string SystemTextJsonSrcGenSerialize() => SystemTextJsonSourceGenerated.Serialize(_fakeNames);
}
