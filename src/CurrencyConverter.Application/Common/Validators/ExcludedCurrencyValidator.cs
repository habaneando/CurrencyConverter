namespace CurrencyConverter.Application;

public class ExcludedCurrencyValidator(
    IExcludedCurrencyProvider ExcludedCurrencyProvider,
    Currency.Factory CurrencyFactory)
    : IExcludedCurrencyValidator
{
    public bool IsValid(string currencyCode)
    {
        var currency = CurrencyFactory
            .Create(currencyCode)
            .GetAwaiter()
            .GetResult();

        return !ExcludedCurrencyProvider.Currencies
            .Exists(c => c.Code == currency.Code);
    }
}
