using BenchmarkDotNet.Attributes;
using FastestWaysInCSharp.StringManipulation;

namespace FastestWaysInCSharp.Benchmarks.StringManipulation;

[Orderer(BenchmarkDotNet.Order.SummaryOrderPolicy.FastestToSlowest)]
[MemoryDiagnoser, DisassemblyDiagnoser(printInstructionAddresses: true, printSource: true, exportDiff: true)]
public class ConvertStringToIntBenchmarks
{
    [Benchmark]
    public int IntParse() => ConvertStringToInt.IntParse();

    [Benchmark]
    public int ConvertToInt32() => ConvertStringToInt.ConvertToInt32();

    [Benchmark]
    public int CustomIntParse() => ConvertStringToInt.CustomIntParse();


    [Benchmark]
    public int CustomIntParseUnsafe() => ConvertStringToInt.CustomIntParseUnsafe();
}
