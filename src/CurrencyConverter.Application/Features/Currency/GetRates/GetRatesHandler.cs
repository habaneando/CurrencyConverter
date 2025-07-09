namespace CurrencyConverter.Application;

public sealed record GetRatesHandler
(
    IGetRatesService GetRatesService,
    GetRatesQueryValidator GetRatesQueryValidator
)
    : IQueryHandler<GetRatesQuery, GetRatesResponse>
{
    public async Task<GetRatesResponse> Handle(GetRatesQuery getRatesQuery, CancellationToken cancellationToken)
    {
        var validation = await GetRatesQueryValidator
            .ValidateAsync(getRatesQuery, cancellationToken)
            .ConfigureAwait(false);

        if (!validation.IsValid)
        {
            throw new BusinessValidationException(
                string.Join(", ", validation.Errors.Select(e => e.ErrorMessage)));
        }

        var currencyRates = await GetRatesService.GetRatesAsync()
            .ConfigureAwait(false);

        var response = new GetRatesResponse
        {
            Amount = currencyRates.Amount,
            Base = currencyRates.Base,
            Date = currencyRates.Date,
            Rates = currencyRates.Rates
        };

        return response;
    }
}
