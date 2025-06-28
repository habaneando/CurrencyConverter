namespace CurrencyConverter.Api;

public static class DI
{
    public static IServiceCollection AddApi(this IServiceCollection services)
    {
        var currencyApiBaseAddress = new Uri("https://api.frankfurter.dev");

        services.AddResilienceRefitClient<IConvertCurrencyService>(currencyApiBaseAddress);

        services.AddResilienceRefitClient<IGetCurrenciesService>(currencyApiBaseAddress);

        services.AddResilienceRefitClient<IGetRatesByCurrencyService>(currencyApiBaseAddress);

        services.AddResilienceRefitClient<IGetRatesService>(currencyApiBaseAddress);
       
        services.AddSingleton<ICurrencyCodeValidator, CurrencyCodeValidator>();

        return services;
    }
}
