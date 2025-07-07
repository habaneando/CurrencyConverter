namespace CurrencyConverter.Application;

public sealed record GetRatesByPeriodHandler
(
    IGetRatesByPeriodService GetRatesByPeriodService,
    GetRatesByPeriodQueryValidator GetRatesByPeriodQueryValidator
) : IQueryHandler<GetRatesByPeriodQuery, GetRatesByPeriodResponse>
{
    public async Task<GetRatesByPeriodResponse> Handle(GetRatesByPeriodQuery getRatesByPeriodQuery, CancellationToken cancellationToken)
    {
        var validation = await GetRatesByPeriodQueryValidator
            .ValidateAsync(getRatesByPeriodQuery, cancellationToken)
            .ConfigureAwait(false);

        if (!validation.IsValid)
        {
            throw new BusinessValidationException(
                string.Join(", ", validation.Errors.Select(e => e.ErrorMessage)));
        }

        var periodCurrencyRates = await GetRatesByPeriodService.GetRatesByPeriodAsync(
            getRatesByPeriodQuery.StartDate,
            getRatesByPeriodQuery.EndDate,
            getRatesByPeriodQuery.Currency)
            .ConfigureAwait(false);

        var periodCurrentRatesPaged = periodCurrencyRates.WithItemsForPage(getRatesByPeriodQuery.Page);

        var response = new GetRatesByPeriodResponse
        {
            Amount = periodCurrencyRates.Amount,
            Base = periodCurrencyRates.Base,
            StartDate = periodCurrencyRates.StartDate,
            EndDate = periodCurrencyRates.EndDate,
            Rates = periodCurrentRatesPaged.Rates
        };

        return response;
    }
}
