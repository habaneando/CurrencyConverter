namespace CurrencyConverter.Api;

public static class DI
{
    public static IServiceCollection AddApi(this IServiceCollection services)
    {
        services.AddSingleton<CurrencyCodeValidator>();
        //services.AddSingleton<ICurrencyCodeValidator, CurrencyCodeValidator>();

        return services;
    }
}
