namespace CurrencyConverter.Application;

public static class DI
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddScoped<IQueryHandler<GetCurrenciesQuery, GetCurrenciesResponse>, GetCurrenciesHandler>();

        services.AddSingleton<GetCurrenciesQueryValidator>();

        return services;
    }
}
