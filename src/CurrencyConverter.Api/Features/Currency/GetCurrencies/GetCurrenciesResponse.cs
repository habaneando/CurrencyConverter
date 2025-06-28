namespace CurrencyConverter.Api;

internal sealed record GetCurrenciesResponse
{
    public Dictionary<string, string> Names { get; init; }
}
