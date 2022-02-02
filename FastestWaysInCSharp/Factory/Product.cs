using Microsoft.Extensions.Logging;

namespace FastestWaysInCSharp.Factory;

public class Product
{
    private readonly ILogger<Product> _logger;

    public int Id { get; }

    public Product(ILogger<Product> logger, int id)
    {
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        Id = id;
    }

    public string Operation() => nameof(Product);
}
