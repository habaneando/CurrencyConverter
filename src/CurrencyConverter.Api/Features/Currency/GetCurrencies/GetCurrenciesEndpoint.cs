using FastEndpoints;

namespace CurrencyConverter.Api;

internal class GetCurrenciesEndpoint(IGetCurrenciesService CurrencyRateService) 
    : EndpointWithoutRequest<GetCurrenciesResponse, GetCurrenciesMapper>
{
    public override void Configure()
    {
        Get("/currencies");
        Group<ApiV1Group>();
        AllowAnonymous();
    }

    public override async Task HandleAsync(CancellationToken ct)
    {
        var currencyName = await CurrencyRateService.GetCurrenciesAsync();

        var getRatesResponse = Map.FromEntity(currencyName);

        await SendOkAsync(getRatesResponse, ct).ConfigureAwait(false);
    }
}
