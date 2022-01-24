using BenchmarkDotNet.Attributes;
using FastestWaysInCSharp.StringManipulation;

namespace FastestWaysInCSharp.Benchmarks.StringManipulation;

[Orderer(BenchmarkDotNet.Order.SummaryOrderPolicy.FastestToSlowest)]
[MemoryDiagnoser, DisassemblyDiagnoser(printInstructionAddresses: true, printSource: true, exportDiff: true)]
public class ConvertStringToIntBenchmarks
{
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE0044:Add readonly modifier", Justification = "Mimic a real-life situation, when the variable is changing.")]
    private static string _numberAsString = "1234567890";

    [Benchmark]
    public int IntParse() => ConvertStringToInt.IntParse(_numberAsString);

    [Benchmark]
    public int ConvertToInt32() => ConvertStringToInt.ConvertToInt32(_numberAsString);

    [Benchmark]
    public int CustomIntParse() => ConvertStringToInt.CustomIntParse(_numberAsString);


    [Benchmark]
    public int CustomIntParseUnsafe() => ConvertStringToInt.CustomIntParseUnsafe(_numberAsString);
}
