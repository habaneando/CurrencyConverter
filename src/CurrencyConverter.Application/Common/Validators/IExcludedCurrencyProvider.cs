namespace CurrencyConverter.Application;

public interface IExcludedCurrencyProvider
{
    List<CurrencyInfo> Currencies { get; }
}
