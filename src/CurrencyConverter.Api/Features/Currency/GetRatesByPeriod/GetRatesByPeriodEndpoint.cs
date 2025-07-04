﻿namespace CurrencyConverter.Api;

internal class GetRatesByPeriodEndpoint(
    IGetRatesByPeriodService GetRatesByPeriodService,
    CacheSettings CacheSettings,
    ThrottleSettings ThrottlingSettings)
    : Endpoint<GetRatesByPeriodRequest, GetRatesByPeriodResponse, GetRatesByPeriodMapper>
{
    public override void Configure()
    {
        Get("/historical-rates/{from}/{to}/{currency}/{page}");

        Group<ApiVersion1Group>();

        ResponseCache(CacheSettings.CacheDurationInSeconds);

        Options(x => x.CacheOutput(p => p.Expire(CacheSettings.CacheDuration)));

        Policies(CurrencyPolicy.Reader);

        Throttle(ThrottlingSettings.HitLimit, ThrottlingSettings.DurationSeconds);

        EnableAntiforgery();
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
