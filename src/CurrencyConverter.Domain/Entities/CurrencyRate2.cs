namespace CurrencyConverter.Domain;

public class CurrencyRate2
{
    [JsonPropertyName("amount")]
    public float Amount { get; set; }

    [JsonPropertyName("base")]
    public string Base { get; set; }

    [JsonPropertyName("date")]
    public DateTime Date { get; set; }

    [JsonPropertyName("rates")]
    public Dictionary<string, float> Rates { get; set; }
}
