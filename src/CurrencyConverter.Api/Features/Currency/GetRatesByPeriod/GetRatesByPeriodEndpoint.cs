using FastEndpoints;

namespace CurrencyConverter.Api;

internal class GetRatesByPeriodEndpoint(
    IGetRatesByPeriodService GetRatesByPeriodService,
    CacheSettings CacheSettings)
    : Endpoint<GetRatesByPeriodRequest, GetRatesByPeriodResponse, GetRatesByPeriodMapper>
{
    public override void Configure()
    {
        Get("/historical-rates/{from}/{to}/{currency}/{page}");
        Group<ApiV1Group>();
        AllowAnonymous();
        ResponseCache(CacheSettings.CacheDurationInSeconds);
        Options(x => x.CacheOutput(p => p.Expire(CacheSettings.CacheDuration)));
    }

    public override async Task HandleAsync(GetRatesByPeriodRequest getRatesByPeriodRequest, CancellationToken ct)
    {
        var periodCurrentRates = await GetRatesByPeriodService.GetRatesByPeriodAsync(
            getRatesByPeriodRequest.from,
            getRatesByPeriodRequest.to,
            getRatesByPeriodRequest.currency)
            .ConfigureAwait(false);

        var periodCurrentRatesPaged =  periodCurrentRates.WithItemsForPage(getRatesByPeriodRequest.page);

        var getRatesByPeriodResponse = Map.FromEntity(periodCurrentRatesPaged);

        await SendOkAsync(getRatesByPeriodResponse, ct)
            .ConfigureAwait(false);
    }
}
