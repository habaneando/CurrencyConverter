namespace CurrencyConverter.Application;

public interface IExcludeCurrencyCodeProvider
{
    List<Currency> ExcludedCurrencies { get; }
}
