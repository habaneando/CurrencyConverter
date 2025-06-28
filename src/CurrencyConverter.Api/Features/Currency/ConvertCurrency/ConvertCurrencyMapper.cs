using CurrencyConverter.Domain;
using FastEndpoints;

namespace CurrencyConverter.Api;

internal sealed class ConvertCurrencyMapper : ResponseMapper<ConvertCurrencyResponse, CurrencyRate>
{
    public override ConvertCurrencyResponse FromEntity(CurrencyRate currencyRate) =>
        new()
        {
            Amount = currencyRate.Amount,
            Base = currencyRate.Base,
            Date = currencyRate.Date,
            Rates = currencyRate.Rates
        };
}
