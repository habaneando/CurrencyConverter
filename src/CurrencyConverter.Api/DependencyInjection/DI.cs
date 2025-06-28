using Refit;

namespace CurrencyConverter.Api;

public static class DI
{
    public static IServiceCollection AddApi(this IServiceCollection services)
    {
        var refitSettings = new RefitSettings
        {
            ContentSerializer = new SystemTextJsonContentSerializer(
                new JsonSerializerOptions
                {
                    Converters = { new DateTimeYyyyMMddConverter() },
                    PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
                    DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull
                })
        };

        var currencyApiBaseAddress = new Uri("https://api.frankfurter.dev");

        services.AddRefitClient<IConvertCurrencyService>(refitSettings)
            .ConfigureHttpClient(c => c.BaseAddress = currencyApiBaseAddress);

        services.AddRefitClient<IGetCurrenciesService>(refitSettings)
            .ConfigureHttpClient(c => c.BaseAddress = currencyApiBaseAddress);

        services.AddRefitClient<IGetRatesByCurrencyService>(refitSettings)
            .ConfigureHttpClient(c => c.BaseAddress = currencyApiBaseAddress);

        services.AddRefitClient<IGetRatesService>(refitSettings)
            .ConfigureHttpClient(c => c.BaseAddress = currencyApiBaseAddress);

        services.AddSingleton<ICurrencyCodeValidator, CurrencyCodeValidator>();

        return services;
    }
}
