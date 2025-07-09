namespace CurrencyConverter.Domain;

public static class DI
{
    public static IServiceCollection AddDomain(this IServiceCollection services)
    {
        services.AddSingleton<ICurrencyProvider, InMemoryCurrencyProvider>();

        services.AddSingleton<Currency2.Factory>();

        services.AddSingleton<Money.Factory>();

        return services;
    }
}
