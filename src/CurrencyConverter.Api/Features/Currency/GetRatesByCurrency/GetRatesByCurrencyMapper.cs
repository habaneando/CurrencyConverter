using CurrencyConverter.Domain;
using FastEndpoints;

namespace CurrencyConverter.Api;

internal sealed class GetRatesByCurrencyMapper : ResponseMapper<GetRatesByCurrencyResponse,CurrencyRate>
{
    public override GetRatesByCurrencyResponse FromEntity(CurrencyRate currencyRate) =>
        new()
        {
            Base = currencyRate.Base,
            Date = currencyRate.Date,
            Rates = currencyRate.Rates
        };
}
