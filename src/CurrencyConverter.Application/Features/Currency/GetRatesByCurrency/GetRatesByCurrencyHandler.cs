namespace CurrencyConverter.Application;

public sealed record GetRatesByCurrencyHandler
(
    IGetRatesByCurrencyService GetRatesByCurrencyService,
    GetRatesByCurrencyQueryValidator GetRatesByCurrencyQueryValidator
) : IQueryHandler<GetRatesByCurrencyQuery, GetRatesByCurrencyResponse>
{
    public async Task<GetRatesByCurrencyResponse> Handle(GetRatesByCurrencyQuery getRatesByCurrencyQuery, CancellationToken cancellationToken)
    {
        var validation = await GetRatesByCurrencyQueryValidator
            .ValidateAsync(getRatesByCurrencyQuery, cancellationToken)
            .ConfigureAwait(false);

        if (!validation.IsValid)
        {
            throw new BusinessValidationException(
                string.Join(", ", validation.Errors.Select(e => e.ErrorMessage)));
        }

        var currencyRates = await GetRatesByCurrencyService.GetRatesByCurrencyAsync(getRatesByCurrencyQuery.currency)
            .ConfigureAwait(false);

        var response = new GetRatesByCurrencyResponse
        {
            Amount = currencyRates.Amount,
            Base = currencyRates.Base,
            Date = currencyRates.Date,
            Rates = currencyRates.Rates
        };

        return response;
    }
}
