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

        services.AddSingleton<ThrottleSettings>();

        services.AddSingleton<IAuthenticationService, MockAuthenticationService>();

        services.AddSingleton<IJwtTokenGeneratorService, JwtTokenGeneratorService>();

        services.AddScoped<IAuthorizationPolicyProvider, MockAuthorizationPolicyProvider>();

        return services;
    }
}
