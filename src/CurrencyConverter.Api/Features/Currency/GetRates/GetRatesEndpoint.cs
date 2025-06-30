using FastEndpoints;

namespace CurrencyConverter.Api;

internal class GetRatesEndpoint(
    IGetRatesService CurrencyRateService,
    CacheSettings CacheSettings,
    ThrottleSettings ThrottlingSettings) 
    : EndpointWithoutRequest<GetRatesResponse, GetRatesMapper>
{
    public override void Configure()
    {
        Get("/rates");

        Group<ApiVersion1Group>();

        ResponseCache(CacheSettings.CacheDurationInSeconds);

        Options(x => x.CacheOutput(p => p.Expire(CacheSettings.CacheDuration)));

        Policies(CurrencyPolicy.Reader);

        Throttle(ThrottlingSettings.HitLimit, ThrottlingSettings.DurationSeconds);

        EnableAntiforgery();
    }

    public override async Task HandleAsync(CancellationToken ct)
    {
        var currentRate = await CurrencyRateService.GetRatesAsync()
            .ConfigureAwait(false);

        var getRatesResponse = Map.FromEntity(currentRate);

        await SendOkAsync(getRatesResponse, ct)
            .ConfigureAwait(false);
    }
}
