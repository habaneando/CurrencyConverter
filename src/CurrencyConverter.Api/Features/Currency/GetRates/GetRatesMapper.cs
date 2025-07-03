namespace CurrencyConverter.Api;

internal sealed class GetRatesMapper : ResponseMapper<GetRatesResponse,CurrencyRates>
{
    public override GetRatesResponse FromEntity(CurrencyRates currencyRates) =>
        new()
        {
            Amount = currencyRates.Amount,
            Base = currencyRates.Base,
            Date = currencyRates.Date,
            Rates = currencyRates.Rates
        };
}
