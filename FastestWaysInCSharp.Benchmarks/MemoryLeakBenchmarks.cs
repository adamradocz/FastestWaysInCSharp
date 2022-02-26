using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Configs;
using Microsoft.Extensions.Logging;

namespace FastestWaysInCSharp.Benchmarks.FileProcessing;

[GroupBenchmarksBy(BenchmarkLogicalGroupRule.ByCategory, BenchmarkLogicalGroupRule.ByParams)]
[MemoryDiagnoser, DisassemblyDiagnoser(printInstructionAddresses: true, printSource: true, exportDiff: true)]
public class MemoryLeakBenchmarks
{
    private JobQueue _queue = new JobQueue();

    [Benchmark]
    public void Normal()
    {
        for (int i = 0; i < 1000000; i++)
        {
            var normal = new NormalClass(_queue);
            normal.Foo();
        }
    }

    [Benchmark]
    public void Leaky()
    {
        for (int i = 0; i < 1000000; i++)
        {
            var leaky = new LeakyClass(_queue);
            leaky.Foo();
        }
    }
}

public class LeakyClass
{
    private readonly ILogger<LeakyClass> _logger;
    private JobQueue _jobQueue;
    private int _id;

    public LeakyClass(JobQueue jobQueue)
    {
        _jobQueue = jobQueue;
        var loggerFactory = new LoggerFactory();
        _logger = loggerFactory.CreateLogger<LeakyClass>();
    }

    public void Foo() => _jobQueue.EnqueueJob(() => _logger.LogCritical("Executing job with ID {Id}", _id));
}


public class NormalClass
{
    private JobQueue _jobQueue;
    private int _id;

    public NormalClass(JobQueue jobQueue)
    {
        _jobQueue = jobQueue;
    }

    public void Foo()
    {
        int id = _id;
        var loggerFactory = new LoggerFactory();
        var logger = loggerFactory.CreateLogger<NormalClass>();
        _jobQueue.EnqueueJob(() => logger.LogCritical("Executing job with ID {Id}", id));
    }
}

public class JobQueue
{
    private string _guid;

    public void EnqueueJob(Action p)
    {
        _guid = Guid.NewGuid().ToString();
        p();
    }
}