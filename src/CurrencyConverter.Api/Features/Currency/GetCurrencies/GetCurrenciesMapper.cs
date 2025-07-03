namespace CurrencyConverter.Api;

internal sealed class GetCurrenciesMapper : ResponseMapper<GetCurrenciesResponse, CurrencyNames>
{
    public GetCurrenciesResponse FromEntity(Dictionary<string, string> currencyNames) =>
        new()
        {
            Names = currencyNames
        };
}
