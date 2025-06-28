using CurrencyConverter.Domain;
using FastEndpoints;

namespace CurrencyConverter.Api;

internal sealed class GetCurrenciesMapper : ResponseMapper<GetCurrenciesResponse, CurrencyName>
{
    public GetCurrenciesResponse FromEntity(Dictionary<string, string> currencyNames) =>
        new()
        {
            Names = currencyNames
        };
}
