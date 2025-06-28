using Microsoft.Extensions.Http.Resilience;
using Polly;

namespace CurrencyConverter.Api;

public static class RefitResilienceExtensions
{
    public static IHttpStandardResiliencePipelineBuilder AddStandardResilience(this IHttpClientBuilder builder) =>
        builder.AddStandardResilienceHandler(options =>
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
}
