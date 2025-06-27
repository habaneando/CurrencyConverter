using CurrencyConverter.Domain;
using FastEndpoints;

namespace CurrencyConverter.Api;

internal sealed class GetRatesMapper : ResponseMapper<GetRatesResponse,CurrencyRate2>
{
    public override GetRatesResponse FromEntity(CurrencyRate2 currencyRate) =>
        new()
        {
            Amount = currencyRate.Amount,
            Base = currencyRate.Base,
            Date = currencyRate.Date,
            Rates = currencyRate.Rates
        };
}
