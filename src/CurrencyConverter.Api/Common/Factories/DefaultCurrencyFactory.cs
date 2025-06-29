namespace CurrencyConverter.Api;

public class DefaultCurrencyFactory : ICurrencyFactory
{
    public Dictionary<string, string> Create() =>
        new Dictionary<string, string>
        {
            { "USD", "United States Dollar" },
            { "EUR", "Euro" },
            { "GBP", "British Pound Sterling" },
            { "JPY", "Japanese Yen" },
            { "AUD", "Australian Dollar" },
            { "CAD", "Canadian Dollar" },
            { "CHF", "Swiss Franc" },
            { "CNY", "Chinese Yuan" },
            { "SEK", "Swedish Krona" },
            { "NZD", "New Zealand Dollar" }
        };
}
