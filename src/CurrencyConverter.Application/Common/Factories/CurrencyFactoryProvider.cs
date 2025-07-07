namespace CurrencyConverter.Application;

public class CurrencyFactoryProvider
{
    private Dictionary<Type, ICurrencyFactory> Factories { get; init; }

    public CurrencyFactoryProvider()
    {
        Factories = new Dictionary<Type, ICurrencyFactory>();
    }

    public ICurrencyFactory Get(Type type) =>
        (Factories.TryGetValue(type, out var factory))
            ? factory
            : new DefaultCurrencyFactory();

    public ICurrencyFactory Get<TRequest>()
        where TRequest : IRefitService =>
        Get(typeof(TRequest));

    public void Add<TRequest, TCurrencyFactory>()
        where TRequest : IRefitService
        where TCurrencyFactory : ICurrencyFactory, new()
    {
        Factories.Add(typeof(TRequest), new TCurrencyFactory());
    }
}
