namespace CurrencyConverter.Application;

public static class DI
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        //Command/Query handlers
        services.AddScoped<IQueryHandler<GetCurrenciesQuery, GetCurrenciesResponse>, GetCurrenciesHandler>();
        services.AddScoped<IQueryHandler<GetRatesQuery, GetRatesResponse>, GetRatesHandler>();
        services.AddScoped<IQueryHandler<GetRatesByCurrencyQuery, GetRatesByCurrencyResponse>, GetRatesByCurrencyHandler>();
        services.AddScoped<IQueryHandler<GetRatesByPeriodQuery, GetRatesByPeriodResponse>, GetRatesByPeriodHandler>();
        services.AddScoped<ICommandHandler<ConvertCurrencyCommand, ConvertCurrencyResponse>, ConvertCurrencyHandler>();

        //Command/Query validators
        services.AddSingleton<GetCurrenciesQueryValidator>();
        services.AddSingleton<GetRatesQueryValidator>();
        services.AddSingleton<GetRatesByCurrencyQueryValidator>();
        services.AddSingleton<GetRatesByPeriodQueryValidator>();
        services.AddSingleton<ConvertCurrencyCommandValidator>();

        return services;
    }
}
