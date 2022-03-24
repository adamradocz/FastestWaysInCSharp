namespace FastestWaysInCSharp.Factory;

public interface IActivatorUtilitiesCreateFactoryGeneric<T> where T : class
{
    T CreateObject(int id);
}