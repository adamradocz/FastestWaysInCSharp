using Microsoft.Extensions.Logging;

namespace FastestWaysInCSharp.Logging;

public partial class ILoggerPerformance
{
    private readonly ILogger<ILoggerPerformance> _logger;
    private readonly Person _person = new() { Name = "Jane Doe", Age = 21 };

    private static readonly Action<ILogger, Person, Exception?> _logHelloWorld = LoggerMessage.Define<Person>(logLevel: LogLevel.Information, eventId: 0, formatString: "Writing hello world response to {Name}");

    [LoggerMessage(0, LogLevel.Information, "Writing hello world response to {Person}")]
    partial void LogHelloWorld(Person person);

    [LoggerMessage(0, LogLevel.Information, "Writing hello world response to {Person}")]
    static partial void StaticLogHelloWorld(ILogger logger, Person person);

    public ILoggerPerformance()
    {
        var loggerFactory = new LoggerFactory();
        _logger = loggerFactory.CreateLogger<ILoggerPerformance>();
    }

    public void StringInterpolation() => _logger.LogInformation($"Writing hello world response to {_person}");

    public void StructuredLogging() => _logger.LogInformation("Writing hello world response to {Person}", _person);

    public void StructuredLoggingLevelChecking()
    {
        if (_logger.IsEnabled(LogLevel.Information))
        {
            _logger.LogInformation("Writing hello world response to {Person}", _person);
        }
    }

    public void LoggerHelperDefine() => _logHelloWorld(_logger, _person, null);

    public void LoggerMessageSourceGenerator() => LogHelloWorld(_person);

    public void LoggerMessageStaticSourceGenerator() => StaticLogHelloWorld(_logger, _person);
}
