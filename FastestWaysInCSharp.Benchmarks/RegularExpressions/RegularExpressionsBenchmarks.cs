using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Configs;
using FastestWaysInCSharp.RegularExpressions;

namespace FastestWaysInCSharp.Benchmarks.FileProcessing;

[Orderer(BenchmarkDotNet.Order.SummaryOrderPolicy.Default)]
[GroupBenchmarksBy(BenchmarkLogicalGroupRule.ByCategory, BenchmarkLogicalGroupRule.ByParams)]
[MemoryDiagnoser, DisassemblyDiagnoser(printInstructionAddresses: true, printSource: true, exportDiff: true)]
public class RegularExpressionsBenchmarks
{
    private readonly EmailAddressValidator _validator = new();

    public string Email => "Molly@jourrapide.com";

    [Benchmark]
    [BenchmarkCategory("Pattern matching")]
    public void Regex() => _validator.Regex(Email);

    [Benchmark]
    [BenchmarkCategory("Pattern matching")]
    public void RegexCompiled() => _validator.RegexCompiled(Email);

    [Benchmark]
    [BenchmarkCategory("Pattern matching")]
    public void RegexSourceGen() => _validator.RegexSourceGen(Email);


    [Benchmark]
    [BenchmarkCategory("Startup")]
    public void RegexStartup() => new EmailAddressValidator().Regex(Email);

    [Benchmark]
    [BenchmarkCategory("Startup")]
    public void RegexCompiledStartup() => new EmailAddressValidator().RegexCompiled(Email);

    [Benchmark]
    [BenchmarkCategory("Startup")]
    public void RegexSourceGenStartup() => new EmailAddressValidator().RegexSourceGen(Email);
}
