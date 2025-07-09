namespace CurrencyConverter.Domain;

public static class DI
{
    public static IServiceCollection AddDomain(this IServiceCollection services)
    {
        services.AddScoped<ICurrencyProvider, InMemoryCurrencyProvider>();

        services.AddScoped<Currency2.Factory>();

        services.AddScoped<Money.Factory>();

        return services;
    }
}
