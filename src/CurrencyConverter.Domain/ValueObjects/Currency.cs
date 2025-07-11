namespace CurrencyConverter.Domain;

public sealed record Currency
{
    public string Code { get; init; }

    public string Symbol { get; init; }

    public int DecimalPlaces { get; init; }

    private Currency(
        string code,
        string symbol,
        int decimalPlaces)
    {
        Guards.EmptyCurrencyCode(code);

        Guards.InvalidISOCurrencyCode(code);

        Guards.EmptyCurrencySymbol(symbol);

        Guards.NegativeDecimalPlaces(decimalPlaces);

        Code = code.ToUpperInvariant();

        Symbol = symbol;

        DecimalPlaces = decimalPlaces;
    }

    public class Factory(ICurrencyProvider CurrencyProvider)
    {
        public async Task<Currency> Create(string currencyCode)
        {
            Guards.EmptyCurrencyCode(currencyCode);

            Guards.InvalidISOCurrencyCode(currencyCode); 

            var info = await CurrencyProvider.GetCurrencyInfo(currencyCode)
                .ConfigureAwait(false);

            return new Currency(
                info.Code,
                info.Symbol,
                info.DecimalPlaces);
        }
    }
}
