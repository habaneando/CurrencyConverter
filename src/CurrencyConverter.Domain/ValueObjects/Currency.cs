namespace CurrencyConverter.Domain;

public record Currency
{
    public string Code { get; init; }

    public string Symbol { get; init; }

    public int DecimalPlaces { get; init; }

    private Currency(
        string code,
        string symbol,
        int decimalPlaces)
    {
        Guard.EmptyCurrencyCode(code);

        Guard.InvalidISOCurrencyCode(code);

        Guard.EmptyCurrencySymbol(symbol);

        Guard.NegativeDecimalPlaces(decimalPlaces);

        Code = code.ToUpperInvariant();

        Symbol = symbol;

        DecimalPlaces = decimalPlaces;
    }

    public class Factory(ICurrencyProvider CurrencyProvider)
    {
        public async Task<Currency> Create(string currencyCode)
        {
            Guard.EmptyCurrencyCode(currencyCode);

            Guard.InvalidISOCurrencyCode(currencyCode); 

            var info = await CurrencyProvider.GetCurrencyInfo(currencyCode)
                .ConfigureAwait(false);

            return new Currency(
                info.Code,
                info.Symbol,
                info.DecimalPlaces);
        }
    }
}
