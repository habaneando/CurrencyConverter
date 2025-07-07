namespace CurrencyConverter.Api;

internal class GetRatesByPeriodEndpoint(
    IQueryHandler<GetRatesByPeriodQuery, GetRatesByPeriodResponse> Handler,
    CacheSettings CacheSettings,
    ThrottleSettings ThrottlingSettings)
    : Endpoint<GetRatesByPeriodRequest, BaseResponse, GetRatesByPeriodMapper>
{
    public override void Configure()
    {
        Get("/historical-rates/{from}/{to}/{currency}/{page}");

        Group<ApiVersion1Group>();

        ResponseCache(CacheSettings.CacheDurationInSeconds);

        Options(x => x.CacheOutput(p => p.Expire(CacheSettings.CacheDuration)));

        AllowAnonymous();
        //Policies(CurrencyPolicy.Reader);

        Throttle(ThrottlingSettings.HitLimit, ThrottlingSettings.DurationSeconds);

        EnableAntiforgery();
    }

    public override async Task HandleAsync(GetRatesByPeriodRequest getRatesByPeriodRequest, CancellationToken ct)
    {
        var query = new GetRatesByPeriodQuery(
            getRatesByPeriodRequest.from,
            getRatesByPeriodRequest.to,
            getRatesByPeriodRequest.currency,
            getRatesByPeriodRequest.page);

        var response = await Handler.Handle(query, ct);

        var map = Map.FromEntity(response);

        await SendOkAsync(map, ct)
            .ConfigureAwait(false);
    }
}
