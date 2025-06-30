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

        services.AddResilienceRefitClient<IGetRatesByPeriodService>(currencyApiBaseAddress);

        services.AddSingleton<ICurrencyCodeValidator, CurrencyCodeValidator>();

        services.AddSingleton<IDateValidator, DateValidator>();

        services.AddSingleton<IExcludeCurrencyCodeProvider, ExcludeCurrencyCodeProvider>();

        services.AddSingleton<IExcludeCurrencyCodeValidator, ExcludeCurrencyCodeValidator>();

        services.AddSingleton<CurrencyFactoryProvider>();

        services.AddSingleton<CacheSettings>();

        services.AddSingleton<IAuthenticationService, AuthenticationService>();

        services.AddSingleton<IJwtTokenGeneratorService, JwtTokenGeneratorService>();

        return services;
    }
}
