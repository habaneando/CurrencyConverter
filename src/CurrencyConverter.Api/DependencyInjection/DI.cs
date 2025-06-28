using Microsoft.Extensions.Http.Resilience;
using Polly;
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
            .ConfigureHttpClient(c => c.BaseAddress = currencyApiBaseAddress)
            .AddStandardResilienceHandler(options =>
            {
                // Retry policy for transient failures
                options.Retry = new HttpRetryStrategyOptions
                {
                    //Limits retries to avoid excessive delays.
                    MaxRetryAttempts = 3,
                    //Base delay between retries.
                    Delay = TimeSpan.FromSeconds(2),
                    //Increases delay exponentially (2s, 4s, 8s).
                    BackoffType = DelayBackoffType.Exponential,
                    //Adds randomness to delays to prevent synchronized retries.
                    UseJitter = true, // Add randomness to prevent thundering herd
                };

                // Circuit breaker to protect against repeated failures
                options.CircuitBreaker = new HttpCircuitBreakerStrategyOptions
                {
                    // Breaks if 50% of requests fail.
                    FailureRatio = 0.5,
                    // Requires 10 requests to evaluate the failure rate.
                    MinimumThroughput = 10,
                    // Circuit stays open for 30 seconds before allowing a test request.
                    BreakDuration = TimeSpan.FromSeconds(30),
                    //Evaluates failures over a 60-second window.
                    SamplingDuration = TimeSpan.FromSeconds(60) 
                };

                // Caps the entire operation, including retries.
                options.TotalRequestTimeout = new HttpTimeoutStrategyOptions
                {
                    Timeout = TimeSpan.FromSeconds(30)
                };
            });

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
