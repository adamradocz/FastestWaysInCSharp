using Microsoft.Extensions.DependencyInjection;

namespace FastestWaysInCSharp.Factory;

public class ActivatorUtilitiesCreateInstance
{
    private readonly IServiceProvider _serviceProvider;

    public ActivatorUtilitiesCreateInstance(IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider ?? throw new ArgumentNullException(nameof(serviceProvider));
    }

    public Product CreateProduct(int id) => ActivatorUtilities.CreateInstance<Product>(_serviceProvider, id);
}
