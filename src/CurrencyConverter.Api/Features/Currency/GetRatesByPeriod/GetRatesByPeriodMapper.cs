namespace CurrencyConverter.Api;

internal sealed class GetRatesByPeriodMapper : ResponseMapper<GetRatesByPeriodResponse, PeriodCurrencyRates>
{
    public override GetRatesByPeriodResponse FromEntity(PeriodCurrencyRates periodCurrencyRates) =>
        new()
        {
            Amount = periodCurrencyRates.Amount,
            Base = periodCurrencyRates.Base,
            StartDate = periodCurrencyRates.StartDate,
            EndDate = periodCurrencyRates.EndDate,
            Rates = periodCurrencyRates.Rates
        };
}
