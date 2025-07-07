namespace CurrencyConverter.Application;

public static class DI
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddScoped<IQueryHandler<GetCurrenciesQuery, GetCurrenciesResponse>, GetCurrenciesHandler>();
        services.AddScoped<IQueryHandler<GetRatesQuery, GetRatesResponse>, GetRatesHandler>();

        services.AddSingleton<GetCurrenciesQueryValidator>();
        services.AddSingleton<GetRatesQueryValidator>();

        return services;
    }
}
