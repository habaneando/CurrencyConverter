using CurrencyConverter.Domain;
using FastEndpoints;

namespace CurrencyConverter.Api;

internal sealed class GetRatesMapper : ResponseMapper<GetRatesResponse,CurrencyRate>
{
    public override GetRatesResponse FromEntity(CurrencyRate currencyRate) =>
        new()
        {
            Amount = currencyRate.Amount,
            Base = currencyRate.Base,
            Date = currencyRate.Date,
            Rates = currencyRate.Rates
        };
}
