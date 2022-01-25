using BenchmarkDotNet.Attributes;
using FastestWaysInCSharp.StringManipulation;

namespace FastestWaysInCSharp.Benchmarks.StringManipulation;

[Orderer (BenchmarkDotNet.Order.SummaryOrderPolicy.FastestToSlowest)]
[MemoryDiagnoser, DisassemblyDiagnoser(printInstructionAddresses: true, printSource: true, exportDiff: true)]
public class MultiSubstringBenchmarks
{
    [Benchmark]
    public string Substring() => MultiSubstring.Substring();

    [Benchmark]
    public string CharArray() => MultiSubstring.CharArray();

    [Benchmark]
    public string CharArrayStackAlloc() => MultiSubstring.CharArrayStackAlloc();

    [Benchmark]
    public string CharArrayStackAllocToString() => MultiSubstring.CharArrayStackAllocToString();

    [Benchmark]
    public string StringCreate() => MultiSubstring.StringCreate();

    [Benchmark]
    public string StringCreateClosure() => MultiSubstring.StringCreateClosure();

    [Benchmark]
    public string StringCreateReverse() => MultiSubstring.StringCreateReverse();

    [Benchmark]
    public string Zstring() => MultiSubstring.Zstring();
}
