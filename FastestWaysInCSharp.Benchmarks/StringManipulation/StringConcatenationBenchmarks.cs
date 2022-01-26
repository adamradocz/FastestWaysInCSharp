using BenchmarkDotNet.Attributes;
using FastestWaysInCSharp.StringManipulation;

namespace FastestWaysInCSharp.Benchmarks.StringManipulation;

[Orderer (BenchmarkDotNet.Order.SummaryOrderPolicy.FastestToSlowest)]
[MemoryDiagnoser, DisassemblyDiagnoser(printInstructionAddresses: true, printSource: true, exportDiff: true)]
public class StringConcatenationBenchmarks
{
    private readonly string _firstName = "Jane";
    private readonly string _lastName = "Doe";
    private readonly int _number = 69;
    private readonly DateOnly _date;

    public StringConcatenationBenchmarks()
    {
        var now = DateTime.Now;
        _date = new DateOnly(now.Year, now.Month, now.Day);
    }

    [Benchmark]
    public void PlusOperator() => StringConcatenation.PlusOperator(_firstName, _lastName, _number, _date);

    [Benchmark]
    public void Interpolation() => StringConcatenation.Interpolation(_firstName, _lastName, _number, _date);

    [Benchmark]
    public void StringConcat() => StringConcatenation.StringConcat(_firstName, _lastName, _number, _date);

    [Benchmark]
    public void StringFormat() => StringConcatenation.StringFormat(_firstName, _lastName, _number, _date);

    [Benchmark]
    public void StringBuilder() => StringConcatenation.StringBuilder(_firstName, _lastName, _number, _date);

    [Benchmark]
    public void StringBuilderPool() => StringConcatenation.StringBuilderPool(_firstName, _lastName, _number, _date);

    [Benchmark]
    public string Zstring() => StringConcatenation.Zstring(_firstName, _lastName, _number, _date);
}
