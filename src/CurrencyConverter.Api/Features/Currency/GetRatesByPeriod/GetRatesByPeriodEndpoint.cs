using FastEndpoints;

namespace CurrencyConverter.Api;

internal class GetRatesByPeriodEndpoint(IGetRatesByPeriodService GetRatesByPeriodService)
    : Endpoint<GetRatesByPeriodRequest, GetRatesByPeriodResponse, GetRatesByPeriodMapper>
{
    public override void Configure()
    {
        Get("/historical-rates/{from}/{to}/{currency}");
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

        var getRatesByPeriodResponse = Map.FromEntity(periodCurrentRates);

        await SendOkAsync(getRatesByPeriodResponse, ct)
            .ConfigureAwait(false);
    }
}
