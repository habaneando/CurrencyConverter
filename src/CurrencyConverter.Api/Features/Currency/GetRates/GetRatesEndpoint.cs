using FastEndpoints;

namespace CurrencyConverter.Api;

internal class GetRatesEndpoint(
    IGetRatesService CurrencyRateService,
    CacheSettings CacheSettings) 
    : EndpointWithoutRequest<GetRatesResponse, GetRatesMapper>
{
    public override void Configure()
    {
        Get("/rates");
        Group<ApiVersion1Group>();
        AllowAnonymous();
        ResponseCache(CacheSettings.CacheDurationInSeconds);
        Options(x => x.CacheOutput(p => p.Expire(CacheSettings.CacheDuration)));
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
