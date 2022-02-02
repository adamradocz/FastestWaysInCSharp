using BenchmarkDotNet.Attributes;
using FastestWaysInCSharp.Factory;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace FastestWaysInCSharp.Benchmarks.StringManipulation;

[Orderer(BenchmarkDotNet.Order.SummaryOrderPolicy.FastestToSlowest)]
[MemoryDiagnoser, DisassemblyDiagnoser(printInstructionAddresses: true, printSource: true, exportDiff: true)]
public class FactoryBenchmarks
{
    private readonly int _id = 69;
    private readonly LoggerFactory _loggerFactory = new ();
    private readonly ServiceProvider _serviceProvider;

    public FactoryBenchmarks()
    {
        var services = new ServiceCollection()
            .AddLogging()
            .AddSingleton<ActivatorUtilitiesCreateInstance>()
            .AddSingleton<ActivatorUtilitiesCreateFactory>();

       _serviceProvider = services.BuildServiceProvider();
    }

    [Benchmark(Baseline = true)]
    public Product NaiveFactory()
    {
        var factroy = new NaiveFactory(_loggerFactory);
        return factroy.CreateProduct(_id);
    }

    [Benchmark(Description = "ActivatorUtilities.CreateInstance")]
    public Product ActivatorUtilitiesCreateInstance()
    {
        var factroy = _serviceProvider.GetRequiredService<ActivatorUtilitiesCreateInstance>();
        return factroy.CreateProduct(_id);
    }

    [Benchmark(Description = "ActivatorUtilities.CreateFactory")]
    public Product ActivatorUtilitiesCreateFactory()
    {
        var factroy = _serviceProvider.GetRequiredService<ActivatorUtilitiesCreateFactory>();
        return factroy.CreateProduct(_id);
    }
}
