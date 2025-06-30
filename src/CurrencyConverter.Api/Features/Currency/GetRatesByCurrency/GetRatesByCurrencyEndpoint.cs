using FastEndpoints;

namespace CurrencyConverter.Api;

internal class GetRatesByCurrencyEndpoint(
    IGetRatesByCurrencyService CurrencyRateService,
    CacheSettings CacheSettings,
    ThrottleSettings ThrottlingSettings) 
    : Endpoint<GetRatesByCurrencyRequest, GetRatesByCurrencyResponse, GetRatesByCurrencyMapper>
{
    public override void Configure()
    {
        Get("/rates/{currency}");

        Group<ApiVersion1Group>();

        ResponseCache(CacheSettings.CacheDurationInSeconds);

        Options(x => x.CacheOutput(p => p.Expire(CacheSettings.CacheDuration)));

        Policies(CurrencyPolicy.Reader);

        Throttle(ThrottlingSettings.HitLimit, ThrottlingSettings.DurationSeconds);

        EnableAntiforgery();
    }

    public override async Task HandleAsync(GetRatesByCurrencyRequest getRatesByCurrencyRequest, CancellationToken ct)
    {
        var currentRate = await CurrencyRateService.GetRatesByCurrencyAsync(getRatesByCurrencyRequest.currency)
            .ConfigureAwait(false);

        var getRatesResponse = Map.FromEntity(currentRate);

        await SendOkAsync(getRatesResponse, ct)
            .ConfigureAwait(false);
    }
}
