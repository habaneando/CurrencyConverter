﻿namespace CurrencyConverter.Api;

internal class GetCurrenciesEndpoint(
    IQueryHandler<GetCurrenciesQuery, GetCurrenciesResponse> Handler,
    CacheSettings CacheSettings,
    ThrottleSettings ThrottlingSettings) 
    : EndpointWithoutRequest<BaseResponse, GetCurrenciesMapper>
{
    public override void Configure()
    {
        Get("/currencies");

        Group<ApiVersion1Group>();

        ResponseCache(CacheSettings.CacheDurationInSeconds);

        Options(x => x.CacheOutput(p => p.Expire(CacheSettings.CacheDuration)));

        AllowAnonymous();
        //Policies(CurrencyPolicy.Reader);

        Throttle(ThrottlingSettings.HitLimit, ThrottlingSettings.DurationSeconds);

        EnableAntiforgery();
    }

    public override async Task HandleAsync(CancellationToken ct)
    {
        var query = new GetCurrenciesQuery();

        var response = await Handler.Handle(query, ct);

        var map = Map.FromEntity(response);

        await SendOkAsync(map, ct)
            .ConfigureAwait(false);
    }
}
