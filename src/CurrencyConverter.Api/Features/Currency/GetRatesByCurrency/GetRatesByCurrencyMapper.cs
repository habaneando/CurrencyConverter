namespace CurrencyConverter.Api;

internal sealed class GetRatesByCurrencyMapper : ResponseMapper<GetRatesByCurrencyResponse,CurrencyRates>
{
    public override GetRatesByCurrencyResponse FromEntity(CurrencyRates currencyRates) =>
        new()
        {
            Amount = currencyRates.Amount,
            Base = currencyRates.Base,
            Date = currencyRates.Date,
            Rates = currencyRates.Rates
        };
}
