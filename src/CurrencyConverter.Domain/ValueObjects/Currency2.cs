namespace CurrencyConverter.Domain;

public record Currency2
{
    public string Code { get; init; }

    public string Symbol { get; init; }

    public int DecimalPlaces { get; init; }

    private Currency2(string code, string symbol, int decimalPlaces)
    {
        if (string.IsNullOrWhiteSpace(Code))
            throw new ArgumentException("Currency code cannot be empty.", nameof(code));

        if (Code.Length != 3 || !Code.All(char.IsLetter))
            throw new ArgumentException("Currency code must be a 3-letter ISO 4217 code.", nameof(code));

        if (string.IsNullOrWhiteSpace(Symbol))
            throw new ArgumentException("Currency symbol cannot be empty.", nameof(symbol));

        if (decimalPlaces < 0)
            throw new ArgumentException("Decimal places cannot be negative.", nameof(decimalPlaces));

        Code = code.ToUpperInvariant();

        Symbol = symbol;

        DecimalPlaces = decimalPlaces;
    }

    public class Factory(ICurrencyProvider CurrencyProvider)
    {
        public Currency2 Create(string currencyCode)
        {
            if (string.IsNullOrWhiteSpace(currencyCode))
                throw new ArgumentException("Currency code cannot be empty.", nameof(currencyCode));

            if (currencyCode.Length != 3 || !currencyCode.All(char.IsLetter))
                throw new ArgumentException("Currency code must be a 3-letter ISO 4217 code.", nameof(currencyCode));

            var info = CurrencyProvider.GetCurrencyInfo(currencyCode);

            return new Currency2(
                info.Code,
                info.Symbol,
                info.DecimalPlaces);
        }
    }
}
