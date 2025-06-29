using CurrencyConverter.Domain;

namespace CurrencyConverter.Api;

public interface IExcludeCurrencyCodeProvider
{
    List<Currency> ExcludedCurrencies { get; }
}
