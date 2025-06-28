namespace CurrencyConverter.Domain;

public sealed record CurrencyNames
{
    public Dictionary<string, string> Names { get; set; }
}
