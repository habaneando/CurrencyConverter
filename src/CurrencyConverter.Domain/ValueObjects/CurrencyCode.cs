namespace CurrencyConverter.Domain;

public class CurrencyCode
{
    public Currency Currency { get; init; }

    private CurrencyCode(Currency currency)
    {
        Currency = currency;
    }

    public static CurrencyCode TryCreate(string currency) =>
        (TryCreate(currency, out Currency currencyResult))
             ? new CurrencyCode(currencyResult)
             : default;

    private static bool TryCreate(string currency, out Currency currencyResult) =>
        Enum.TryParse(currency, true, out currencyResult);
}
