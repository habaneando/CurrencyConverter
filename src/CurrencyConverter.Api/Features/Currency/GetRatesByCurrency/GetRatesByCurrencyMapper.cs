using CurrencyConverter.Domain;
using FastEndpoints;

namespace CurrencyConverter.Api;

internal sealed class GetRatesByCurrencyMapper : ResponseMapper<GetRatesByCurrencyResponse,CurrencyRate2>
{
    public override GetRatesByCurrencyResponse FromEntity(CurrencyRate2 currencyRate) =>
        new()
        {
            Base = currencyRate.Base,
            Date = currencyRate.Date,
            Rates = currencyRate.Rates
        };
}
