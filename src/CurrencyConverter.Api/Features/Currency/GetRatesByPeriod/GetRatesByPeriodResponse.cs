namespace CurrencyConverter.Api;

internal sealed record GetRatesByPeriodResponse
{
    public required float Amount { get; init; }

    public required string Base { get; init; }

    [JsonConverter(typeof(DateTimeYyyyMMddConverter))]
    public required DateTime StartDate { get; init; }

    [JsonConverter(typeof(DateTimeYyyyMMddConverter))]
    public required DateTime EndDate { get; init; }

    public Dictionary<string, Dictionary<string, float>> Rates { get; init; }
}
