using FastEndpoints;

namespace CurrencyConverter.Api;

internal class GetRatesByCurrencyEndpoint(IGetRatesByCurrencyService CurrencyRateService) 
    : Endpoint<GetRatesByCurrencyRequest, GetRatesByCurrencyResponse, GetRatesByCurrencyMapper>
{
    public override void Configure()
    {
        Get("/rates/{currency}");
        Group<ApiV1Group>();
        AllowAnonymous();
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
