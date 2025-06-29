using FastEndpoints;

namespace CurrencyConverter.Api;

internal class GetRatesByPeriodEndpoint(IGetRatesByPeriodService GetRatesByPeriodService)
    : Endpoint<GetRatesByPeriodRequest, GetRatesByPeriodResponse, GetRatesByPeriodMapper>
{
    public override void Configure()
    {
        Get("/historical-rates/{from}/{to}/{currency}/{page}");
        Group<ApiV1Group>();
        AllowAnonymous();
    }

    public override async Task HandleAsync(GetRatesByPeriodRequest getRatesByPeriodRequest, CancellationToken ct)
    {
        var periodCurrentRates = await GetRatesByPeriodService.GetRatesByPeriodAsync(
            getRatesByPeriodRequest.from,
            getRatesByPeriodRequest.to,
            getRatesByPeriodRequest.currency)
            .ConfigureAwait(false);

        var kvp = periodCurrentRates.Rates.ToList();

        var kvpPaged = new PagedList<KeyValuePair<string, Dictionary<string, float>>>(kvp).GetItemsForPage(getRatesByPeriodRequest.page);

        periodCurrentRates.Rates = new Dictionary<string, Dictionary<string, float>>(kvpPaged);

        var getRatesByPeriodResponse = Map.FromEntity(periodCurrentRates);

        await SendOkAsync(getRatesByPeriodResponse, ct)
            .ConfigureAwait(false);
    }
}
