namespace CurrencyConverter.Api;

internal sealed record GetRatesByCurrencyResponse
{
    public required string Base { get; init; }
    
    public required DateTime Date { get; init; }

    public Dictionary<string, float> Rates { get; init; }
}
