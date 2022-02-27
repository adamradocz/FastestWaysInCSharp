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

    [Benchmark(Description = "Regex - Pattern matching")]
    [BenchmarkCategory("Pattern matching")]
    public void Regex() => _validator.Regex(Email);

    [Benchmark(Description = "RegexCompiled - Pattern matching")]
    [BenchmarkCategory("Pattern matching")]
    public void RegexCompiled() => _validator.RegexCompiled(Email);

    [Benchmark(Description = "RegexSourceGen - Pattern matching")]
    [BenchmarkCategory("Pattern matching")]
    public void RegexSourceGen() => _validator.RegexSourceGen(Email);


    [Benchmark(Description = "Regex - Startup")]
    [BenchmarkCategory("Startup")]
    public void RegexStartup() => new EmailAddressValidator().Regex(Email);

    [Benchmark(Description = "RegexCompiled - Startup")]
    [BenchmarkCategory("Startup")]
    public void RegexCompiledStartup() => new EmailAddressValidator().RegexCompiled(Email);

    [Benchmark(Description = "RegexSourceGen - Startup")]
    [BenchmarkCategory("Startup")]
    public void RegexSourceGenStartup() => new EmailAddressValidator().RegexSourceGen(Email);
}
