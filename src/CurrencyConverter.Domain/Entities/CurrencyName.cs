namespace CurrencyConverter.Domain;

public sealed record CurrencyName
{
    public Dictionary<string, string> Names { get; set; }
}
