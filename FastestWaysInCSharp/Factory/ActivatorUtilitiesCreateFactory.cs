using Microsoft.Extensions.DependencyInjection;

namespace FastestWaysInCSharp.Factory;

public class ActivatorUtilitiesCreateFactory
{
    private readonly IServiceProvider _serviceProvider;
    private readonly ObjectFactory _factory;

    public ActivatorUtilitiesCreateFactory(IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider ?? throw new ArgumentNullException(nameof(serviceProvider));
        _factory = ActivatorUtilities.CreateFactory(typeof(Product), new Type[] { typeof(int) });
    }

    public Product CreateProduct(int id) => (Product)_factory(_serviceProvider, new object[] { id });
}
