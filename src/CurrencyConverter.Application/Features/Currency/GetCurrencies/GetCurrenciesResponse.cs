namespace CurrencyConverter.Application;

public sealed record GetCurrenciesResponse
{
    public Dictionary<string, string> Names { get; init; } = [];
}
