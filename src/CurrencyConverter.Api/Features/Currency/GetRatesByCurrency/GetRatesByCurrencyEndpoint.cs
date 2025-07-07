namespace CurrencyConverter.Api;

internal class GetRatesByCurrencyEndpoint(
    IQueryHandler<GetRatesByCurrencyQuery, GetRatesByCurrencyResponse> Handler,
    CacheSettings CacheSettings,
    ThrottleSettings ThrottlingSettings) 
    : Endpoint<GetRatesByCurrencyRequest, BaseResponse, GetRatesByCurrencyMapper>
{
    public override void Configure()
    {
        Get("/rates/{currency}");

        Group<ApiVersion1Group>();

        ResponseCache(CacheSettings.CacheDurationInSeconds);

        Options(x => x.CacheOutput(p => p.Expire(CacheSettings.CacheDuration)));

        AllowAnonymous();
        //Policies(CurrencyPolicy.Reader);

        Throttle(ThrottlingSettings.HitLimit, ThrottlingSettings.DurationSeconds);

        EnableAntiforgery();
    }

    public override async Task HandleAsync(GetRatesByCurrencyRequest getRatesByCurrencyRequest, CancellationToken ct)
    {
        var query = new GetRatesByCurrencyQuery(getRatesByCurrencyRequest.currency);

        var response = await Handler.Handle(query, ct);

        var map = Map.FromEntity(response);

        await SendOkAsync(map, ct)
            .ConfigureAwait(false);
    }
}
