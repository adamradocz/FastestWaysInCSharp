using BenchmarkDotNet.Attributes;
using FastestWaysInCSharp.StringManipulation;

namespace FastestWaysInCSharp.Benchmarks.StringManipulation;

[Orderer (BenchmarkDotNet.Order.SummaryOrderPolicy.FastestToSlowest)]
[MemoryDiagnoser, DisassemblyDiagnoser(printInstructionAddresses: true, printSource: true, exportDiff: true)]
public class MultiSubstringBenchmarks
{
    [Benchmark(Baseline = true, Description = "Substring")]
    public string Substring() => MultiSubstring.Substring();

    [Benchmark(Description = "CharArray")]
    public string CharArray() => MultiSubstring.CharArray();

    [Benchmark(Description = "CharArray - StackAlloc")]
    public string CharArrayStackAlloc() => MultiSubstring.CharArrayStackAlloc();

    [Benchmark(Description = "CharArray - StackAlloc - ToString")]
    public string CharArrayStackAllocToString() => MultiSubstring.CharArrayStackAllocToString();

    [Benchmark(Description = "String.Create")]
    public string StringCreate() => MultiSubstring.StringCreate();

    [Benchmark(Description = "String.Create - Closure")]
    public string StringCreateClosure() => MultiSubstring.StringCreateClosure();

    [Benchmark(Description = "String.Create - Reverse")]
    public string StringCreateReverse() => MultiSubstring.StringCreateReverse();

    [Benchmark(Description = "String.Create - Reverse - SkipLocalsInit")]
    public string StringCreateReverseSkipLocalsInit() => MultiSubstring.StringCreateReverseSkipLocalsInit();

    [Benchmark(Description = "Zstring")]
    public string Zstring() => MultiSubstring.Zstring();
}
