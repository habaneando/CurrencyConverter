using FastEndpoints;

namespace CurrencyConverter.Api;

internal class GetRatesEndpoint(IGetRatesService CurrencyRateService) 
    : EndpointWithoutRequest<GetRatesResponse, GetRatesMapper>
{
    public override void Configure()
    {
        Get("/api/v1/rates");
        AllowAnonymous();
    }

    public override async Task HandleAsync(CancellationToken ct)
    {
        var currentRate = await CurrencyRateService.GetRatesAsync();

        var getRatesResponse = Map.FromEntity(currentRate);

        await SendOkAsync(getRatesResponse, ct).ConfigureAwait(false);
    }
}
