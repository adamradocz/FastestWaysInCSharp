using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Configs;
using FastestWaysInCSharp.RegularExpressions;

namespace FastestWaysInCSharp.Benchmarks.FileProcessing;

[Orderer(BenchmarkDotNet.Order.SummaryOrderPolicy.Default)]
[GroupBenchmarksBy(BenchmarkLogicalGroupRule.ByCategory, BenchmarkLogicalGroupRule.ByParams)]
[MemoryDiagnoser, DisassemblyDiagnoser(printInstructionAddresses: true, printSource: true, exportDiff: true)]
public class RegularExpressionsBenchmarks
{
    public static string Email => "Molly@jourrapide.com";

    [Benchmark(Description = "Regex - Pattern matching")]
    [BenchmarkCategory("Pattern matching")]
    public void Regex() => EmailAddressValidator.Regex(Email);

    [Benchmark(Description = "RegexCompiled - Pattern matching")]
    [BenchmarkCategory("Pattern matching")]
    public void RegexCompiled() => EmailAddressValidator.RegexCompiled(Email);

    [Benchmark(Description = "RegexSourceGen - Pattern matching")]
    [BenchmarkCategory("Pattern matching")]
    public void RegexSourceGen() => EmailAddressValidator.RegexSourceGen(Email);
}
