using Microsoft.Extensions.Logging;

namespace FastestWaysInCSharp.Factory;

public class NaiveFactory
{
    private readonly ILogger<Product> _logger;

    public NaiveFactory(LoggerFactory loggerFactory)
    {
        _logger = loggerFactory.CreateLogger<Product>();
    }

    public Product CreateProduct(int id) => new(_logger, id);
}
