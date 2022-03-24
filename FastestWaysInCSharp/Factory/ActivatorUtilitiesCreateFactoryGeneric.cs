using Microsoft.Extensions.DependencyInjection;

namespace FastestWaysInCSharp.Factory;

public class ActivatorUtilitiesCreateFactoryGeneric<T> : IActivatorUtilitiesCreateFactoryGeneric<T> where T : class
{
    private readonly IServiceProvider _serviceProvider;
    private readonly ObjectFactory _factory;

    public ActivatorUtilitiesCreateFactoryGeneric(IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider ?? throw new ArgumentNullException(nameof(serviceProvider));
        _factory = ActivatorUtilities.CreateFactory(typeof(T), new Type[] { typeof(int) });
    }

    public T CreateObject(int id) => (T)_factory(_serviceProvider, new object[] { id });
}
