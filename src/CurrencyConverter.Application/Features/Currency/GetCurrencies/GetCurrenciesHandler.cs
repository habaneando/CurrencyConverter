namespace CurrencyConverter.Application;

public sealed record GetCurrenciesHandler
(
    IGetCurrenciesService CurrencyRateService
) : IQueryHandler<GetCurrenciesQuery, GetCurrenciesResponse>
{
    public async Task<GetCurrenciesResponse> Handle(GetCurrenciesQuery request, CancellationToken cancellationToken)
    {
        var currencyNames = await CurrencyRateService.GetCurrenciesAsync()
            .ConfigureAwait(false);

        var response = new GetCurrenciesResponse
        {
            Names = currencyNames
        };

        return response;
    }
}
