namespace CurrencyConverter.Domain;

public record Currency2
{
    public string Code { get; init; }

    public string Symbol { get; init; }

    public int DecimalPlaces { get; init; }

    private Currency2(string code, string symbol, int decimalPlaces)
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
        public async Task<Currency2> Create(string currencyCode)
        {
            Guard.EmptyCurrencyCode(currencyCode);

            Guard.InvalidISOCurrencyCode(currencyCode); 

            var info = await CurrencyProvider.GetCurrencyInfo(currencyCode)
                .ConfigureAwait(false);

            return new Currency2(
                info.Code,
                info.Symbol,
                info.DecimalPlaces);
        }
    }
}
