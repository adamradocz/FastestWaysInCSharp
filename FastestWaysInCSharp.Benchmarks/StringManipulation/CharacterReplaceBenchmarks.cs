using BenchmarkDotNet.Attributes;
using FastestWaysInCSharp.StringManipulation;

namespace FastestWaysInCSharp.Benchmarks.StringManipulation;

[Orderer(BenchmarkDotNet.Order.SummaryOrderPolicy.FastestToSlowest)]
[MemoryDiagnoser, DisassemblyDiagnoser(printInstructionAddresses: true, printSource: true, exportDiff: true)]
public class CharacterReplaceBenchmarks
{
    [Benchmark]
    public string Substring() => CharacterReplace.Substring();

    [Benchmark]
    public string StringCreate() => CharacterReplace.StringCreate();

    [Benchmark]
    public string Unsafe() => CharacterReplace.Unsafe();
}
