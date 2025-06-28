namespace CurrencyConverter.Api;

internal sealed record ConvertCurrencyResponse
{
    public required float Amount { get; init; }

    public required string Base { get; init; }

    [JsonConverter(typeof(DateTimeYyyyMMddConverter))]
    public required DateTime Date { get; init; }

    public Dictionary<string, float> Rates { get; init; }
}
