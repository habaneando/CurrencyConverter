using FastEndpoints;

namespace CurrencyConverter.Api;

internal class GetCurrenciesEndpoint(
    IGetCurrenciesService CurrencyRateService,
    CacheSettings CacheSettings) 
    : EndpointWithoutRequest<GetCurrenciesResponse, GetCurrenciesMapper>
{
    public override void Configure()
    {
        Get("/currencies");
        Group<ApiVersion1Group>();
        ResponseCache(CacheSettings.CacheDurationInSeconds);
        Options(x => x.CacheOutput(p => p.Expire(CacheSettings.CacheDuration)));
        Policies(CurrencyPolicy.Reader);
    }

    public override async Task HandleAsync(CancellationToken ct)
    {
        var currencyName = await CurrencyRateService.GetCurrenciesAsync()
            .ConfigureAwait(false);

        var getRatesResponse = Map.FromEntity(currencyName);

        await SendOkAsync(getRatesResponse, ct)
            .ConfigureAwait(false);
    }
}
