namespace CurrencyConverter.Domain;

public class InMemoryCurrencyProvider : ICurrencyProvider
{
    private readonly Dictionary<string, CurrencyInfo> _currencies = new()
    {
        { "USD", new("USD", "$", 2) },
        { "EUR", new("EUR", "€", 2) },
        { "JPY", new("JPY", "¥", 0) },
        { "GBP", new("GBP", "£", 2) },
        { "CHF", new("CHF", "CHF", 2) },
        { "BTC", new("BTC", "₿", 8) },
        { "TRY", new("TRY", "₺", 2) },
        { "PLN", new("PLN", "zł", 2) },
        { "THB", new("THB", "฿", 2) },
        { "MXN", new("MXN", "$", 2) }
    };

    public Task<CurrencyInfo> GetCurrencyInfo(string currencyCode)
    {
        if (!_currencies.TryGetValue(currencyCode.ToUpperInvariant(), out var info))
            throw new ArgumentException($"Currency code '{currencyCode}' is not supported.", nameof(currencyCode));

        return Task.FromResult(info);
    }
}
