namespace CurrencyConverter.Domain;

public sealed record PeriodCurrencyRates
{
    [JsonPropertyName("amount")]
    public float Amount { get; set; }

    [JsonPropertyName("base")]
    public string Base { get; set; }

    [JsonPropertyName("from")]
    public DateTime StartDate { get; set; }

    [JsonPropertyName("to")]
    public DateTime EndDate { get; set; }

    [JsonPropertyName("rates")]
    public Dictionary<string, Dictionary<string, float>> Rates { get; set; }
}
