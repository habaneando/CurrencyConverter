namespace CurrencyConverter.Api;

internal sealed class ConvertCurrencyMapper : ResponseMapper<ConvertCurrencyResponse, CurrencyRates>
{
    public override ConvertCurrencyResponse FromEntity(CurrencyRates currencyRates) =>
        new()
        {
            Amount = currencyRates.Amount,
            Base = currencyRates.Base,
            Date = currencyRates.Date,
            Rates = currencyRates.Rates
        };
}
