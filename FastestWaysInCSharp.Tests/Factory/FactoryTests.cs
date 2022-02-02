using FastestWaysInCSharp.Factory;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FastestWaysInCSharp.Tests.Factory;

[TestClass]
public class FactoryTests
{
    private readonly int _id = 69;

    [TestMethod]
    public void Naive_CreatePoductWithParameter_ReturnsProduct()
    {
        // Arrange
        var loggerFactory = new LoggerFactory();
        var factroy = new NaiveFactory(loggerFactory);

        // Act
        var product = factroy.CreateProduct(_id);

        // Assert
        Assert.AreEqual(_id, product.Id);
        Assert.AreEqual("Product", product.Operation());
    }

    [TestMethod]
    public void ActivatorUtilitiesCreateInstance_CreatePoductWithParameter_ReturnsProduct()
    {
        // Arrange
        var services = new ServiceCollection()
            .AddLogging()
            .AddSingleton<ActivatorUtilitiesCreateInstance>();

        var serviceProvider = services.BuildServiceProvider();
        var factroy = serviceProvider.GetRequiredService<ActivatorUtilitiesCreateInstance>();

        // Act
        var product = factroy.CreateProduct(_id);

        // Assert
        Assert.AreEqual(_id, product.Id);
        Assert.AreEqual("Product", product.Operation());
    }


    [TestMethod]
    public void ActivatorUtilitiesCreateFactory_CreatePoductWithParameter_ReturnsProduct()
    {
        // Arrange
        var services = new ServiceCollection()
            .AddLogging()
            .AddSingleton<ActivatorUtilitiesCreateFactory>();

        var serviceProvider = services.BuildServiceProvider();
        var factroy = serviceProvider.GetRequiredService<ActivatorUtilitiesCreateFactory>();

        // Act
        var product = factroy.CreateProduct(_id);

        // Assert
        Assert.AreEqual(_id, product.Id);
        Assert.AreEqual("Product", product.Operation());
    }
}
