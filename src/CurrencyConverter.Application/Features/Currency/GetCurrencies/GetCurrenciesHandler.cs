namespace CurrencyConverter.Application;

public sealed record GetCurrenciesHandler
(
    IGetCurrenciesService GetCurrenciesService,
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

        var currencyNames = await GetCurrenciesService.GetCurrenciesAsync()
            .ConfigureAwait(false);

        var response = new GetCurrenciesResponse
        {
            Names = currencyNames
        };

        return response;
    }
}
