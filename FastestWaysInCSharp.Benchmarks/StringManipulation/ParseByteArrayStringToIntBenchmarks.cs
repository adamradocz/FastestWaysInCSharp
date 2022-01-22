using BenchmarkDotNet.Attributes;
using FastestWaysInCSharp.StringManipulation;

namespace FastestWaysInCSharp.Benchmarks.StringManipulation;

[Orderer(BenchmarkDotNet.Order.SummaryOrderPolicy.FastestToSlowest)]
[MemoryDiagnoser, DisassemblyDiagnoser(printInstructionAddresses: true, printSource: true, exportDiff: true)]
public class ParseByteArrayStringToIntBenchmarks
{
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE0044:Add readonly modifier", Justification = "Mimic a real-life situation, when the variable is changing.")]
    private static byte[] _stringAsByteArray = System.Text.Encoding.UTF8.GetBytes("1234567890");

    [Benchmark]
    public int GetStringIntParse() => ParseByteArrayStringToInt.GetStringIntParse(_stringAsByteArray);

    [Benchmark]
    public int Utf8ParserTryParse() => ParseByteArrayStringToInt.Utf8ParserTryParse(_stringAsByteArray);

    [Benchmark]
    public int CustomIntParse() => ParseByteArrayStringToInt.CustomIntParse(_stringAsByteArray);
}
