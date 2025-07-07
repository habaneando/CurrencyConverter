namespace CurrencyConverter.Application;

public sealed record GetCurrenciesHandler
(
    IGetCurrenciesService CurrencyRateService,
    GetCurrenciesQueryValidator GetCurrenciesQueryValidator
) : IQueryHandler<GetCurrenciesQuery, GetCurrenciesResponse>
{
    public async Task<GetCurrenciesResponse> Handle(GetCurrenciesQuery getCurrenciesQuery, CancellationToken cancellationToken)
    {
        var validation = await GetCurrenciesQueryValidator
            .ValidateAsync(getCurrenciesQuery, cancellationToken)
            .ConfigureAwait(false);

        if (!validation.IsValid)
        {
            throw new BusinessValidationException(
                string.Join(", ", validation.Errors.Select(e => e.ErrorMessage)));
        }

        var currencyNames = await CurrencyRateService.GetCurrenciesAsync()
            .ConfigureAwait(false);

        var response = new GetCurrenciesResponse
        {
            Names = currencyNames
        };

        return response;
    }
}
