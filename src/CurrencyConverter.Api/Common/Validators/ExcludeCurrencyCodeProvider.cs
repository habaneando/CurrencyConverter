using CurrencyConverter.Domain;

namespace CurrencyConverter.Api;

public class ExcludeCurrencyCodeProvider : IExcludeCurrencyCodeProvider
{
    public List<Currency> ExcludedCurrencies =>
        new List<Currency>
        {
            Currency.TRY,
            Currency.PLN,
            Currency.THB,
            Currency.MXN
        };
}
