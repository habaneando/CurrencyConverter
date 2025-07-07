namespace CurrencyConverter.Application;

public class ExcludeCurrencyCodeValidator(IExcludeCurrencyCodeProvider ExcludeCurrencyCodeProvider) : IExcludeCurrencyCodeValidator
{
    public bool IsNotAllowed(string currency) =>
        ExcludeCurrencyCodeProvider.ExcludedCurrencies
            .Contains(CurrencyCode.TryCreate(currency).Currency);
}
