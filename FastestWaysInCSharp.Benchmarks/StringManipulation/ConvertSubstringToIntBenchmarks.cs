using BenchmarkDotNet.Attributes;
using FastestWaysInCSharp.StringManipulation;

namespace FastestWaysInCSharp.Benchmarks.StringManipulation;

[Orderer(BenchmarkDotNet.Order.SummaryOrderPolicy.FastestToSlowest)]
[MemoryDiagnoser, DisassemblyDiagnoser(printInstructionAddresses: true, printSource: true, exportDiff: true)]
public class ConvertSubstringToIntBenchmarks
{
    [Benchmark]
    public int SubstringIntParse() => ConvertSubstringToInt.SubstringIntParse();

    [Benchmark]
    public int SpanIntParse() => ConvertSubstringToInt.SpanIntParse();

    [Benchmark]
    public int SpanGenericCustomParse() => ConvertSubstringToInt.SpanGenericCustomParse();

    [Benchmark]
    public int SpecificCustomIntParse() => ConvertSubstringToInt.SpecificCustomIntParse();
}
